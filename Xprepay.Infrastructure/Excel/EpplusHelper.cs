using OfficeOpenXml;
using OfficeOpenXml.Table;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Xprepay.Excel
{
    public static class EpplusHelper
    {
        /// <summary>
        /// 泛型方式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public static IEnumerable<T> LoadFromExcel<T>(string fileName) where T : new()
        {
            FileInfo existingFile = new FileInfo(fileName);
            List<T> resultList = new List<T>();
            Dictionary<string, int> dictHeader = new Dictionary<string, int>();

            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];

                int colStart = worksheet.Dimension.Start.Column;  //工作区开始列
                int colEnd = worksheet.Dimension.End.Column;       //工作区结束列
                int rowStart = worksheet.Dimension.Start.Row + 1;       //工作区开始行号
                int rowEnd = worksheet.Dimension.End.Row;       //工作区结束行号

                //将每列标题添加到字典中
                for (int i = colStart; i <= colEnd; i++)
                {
                    dictHeader[worksheet.Cells[rowStart, i].Value.ToString()] = i;
                }

                List<PropertyInfo> propertyInfoList = new List<PropertyInfo>(typeof(T).GetProperties());

                for (int row = rowStart + 1; row <= rowEnd; row++)//从第二行开始读取数据
                {
                    T result = new T();
                    bool isnull = false;
                    //为对象T的各属性赋值
                    foreach (PropertyInfo p in propertyInfoList)
                    {
                        try
                        {

                            ExcelRange cell = worksheet.Cells[row, dictHeader[p.Name]]; //与属性名对应的单元格

                            if (cell.Value == null)
                            {
                                isnull = true;
                                break;
                            }
                            if (p.PropertyType.IsGenericType)
                            {
                                string type = p.PropertyType.GetGenericArguments()[0].ToString().ToLower();
                                switch (type.Split('.')[1])
                                {
                                    case "guid":
                                        p.SetValue(result, new Guid(cell.Text));
                                        break;
                                    case "string":
                                        p.SetValue(result, cell.GetValue<String>());
                                        break;
                                    case "int16":
                                        p.SetValue(result, cell.GetValue<Int16>());
                                        break;
                                    case "int32":
                                        p.SetValue(result, cell.GetValue<Int32>());
                                        break;
                                    case "int64":
                                        p.SetValue(result, cell.GetValue<Int64>());
                                        break;
                                    case "decimal":
                                        p.SetValue(result, cell.GetValue<Decimal>());
                                        break;
                                    case "double":
                                        p.SetValue(result, cell.GetValue<Double>());
                                        break;
                                    case "datetime":
                                        p.SetValue(result, cell.GetValue<DateTime>());
                                        break;
                                    case "boolean":
                                        p.SetValue(result, cell.GetValue<Boolean>());
                                        break;
                                    case "byte":
                                        p.SetValue(result, cell.GetValue<Byte>());
                                        break;
                                    case "char":
                                        p.SetValue(result, cell.GetValue<Char>());
                                        break;
                                    case "single":
                                        p.SetValue(result, cell.GetValue<Single>());
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                switch (p.PropertyType.Name.ToLower())
                                {
                                    case "guid":
                                        p.SetValue(result, new Guid(cell.Text));
                                        break;
                                    case "string":
                                        p.SetValue(result, cell.GetValue<String>());
                                        break;
                                    case "int16":
                                        p.SetValue(result, cell.GetValue<Int16>());
                                        break;
                                    case "int32":
                                        p.SetValue(result, cell.GetValue<Int32>());
                                        break;
                                    case "int64":
                                        p.SetValue(result, cell.GetValue<Int64>());
                                        break;
                                    case "decimal":
                                        p.SetValue(result, cell.GetValue<Decimal>());
                                        break;
                                    case "double":
                                        p.SetValue(result, cell.GetValue<Double>());
                                        break;
                                    case "datetime":
                                        p.SetValue(result, cell.GetValue<DateTime>());
                                        break;
                                    case "boolean":
                                        p.SetValue(result, cell.GetValue<Boolean>());
                                        break;
                                    case "byte":
                                        p.SetValue(result, cell.GetValue<Byte>());
                                        break;
                                    case "char":
                                        p.SetValue(result, cell.GetValue<Char>());
                                        break;
                                    case "single":
                                        p.SetValue(result, cell.GetValue<Single>());
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                        catch (KeyNotFoundException ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    }
                    if (!isnull)
                    {
                        resultList.Add(result);
                    }
                }
            }
            return resultList;
        }
        public static void SaveToExcel<T>(IEnumerable<T> data, string fileName, string OpenPassword = "")
        {
            FileInfo file = new FileInfo(fileName);
            string path = Path.GetDirectoryName(fileName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            try
            {
                using (ExcelPackage ep = new ExcelPackage(file, OpenPassword))
                {
                    ExcelWorksheet ws = ep.Workbook.Worksheets.Add(typeof(T).Name);
                    ws.Cells["A1"].LoadFromCollection(data, true, TableStyles.Medium10);
                    ep.Save(OpenPassword);
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static string SaveToExcel<T>(IEnumerable<T> data, string fileName, string[] title)
        {
            FileInfo file = new FileInfo(fileName);
            string path = Path.GetDirectoryName(fileName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            try
            {
                using (ExcelPackage ep = new ExcelPackage(file))//创建
                {
                    ExcelWorksheet ws = ep.Workbook.Worksheets[typeof(T).Name];
                    if (ws == null)
                    {
                        ws = ep.Workbook.Worksheets.Add(typeof(T).Name);//添加sheet
                    }
                    for (int i = 0; i < title.Length; i++)
                    {
                        ws.Cells[1, i + 1].Value = title[i];
                    }
                    ws.Cells["A2"].LoadFromCollection(data, true, TableStyles.Medium10);
                    ep.Save();
                }
            }
            catch (Exception ex)
            {
                return fileName = "error";
            }
            return fileName;
        }
    }
}
