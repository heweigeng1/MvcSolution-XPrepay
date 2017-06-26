using System.Collections.Generic;
using System.Web.Mvc;

namespace System

{
    public static class EnumExtentions
    {
        /// <summary>
        /// 枚举类型转换List<SelectListItem>
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<SelectListItem> EnumConvertToSelectListItem(this Type type)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            if (type.IsEnum)
            {
                string[] names = Enum.GetNames(type);
                foreach (string name in names)
                {
                    list.Add(new SelectListItem { Text = name, Value = Enum.Format(type, Enum.Parse(type, name), "d") ,Selected=false});
                }
            }
            return list;
        }
        /// <summary>
        /// 枚举类型转换到键值对列表
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<KeyValuePair<string, string>> EnumConvertToList(this Type type)
        {
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
            if (type.IsEnum)
            {
                string[] names = Enum.GetNames(type);
                foreach (string name in names)
                    list.Add(new KeyValuePair<string, string>(name, Enum.Format(type, Enum.Parse(type, name), "d")));
            }
            return list;
        }
    }
}
