using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace Xprepay
{
    public static class ImageExtensions
    {
        private static int maxSize = 4 * 1024 * 1024;//最大4MB
        private static string p400X400 = @"p400X400_";//压缩大小
        private static string p200X200 = @"p200X200_";
        private static string p100 = @"p100_";//原图
        private static string RootPath = @"/Upload/Img";
        /// <summary>
        /// 大小
        /// </summary>
        /// <param name="image"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static Image ToSize(this Image image, Size size)
        {
            if (image.Width <= size.Width && image.Height <= size.Height)
            {
                return new Bitmap(image);
            }

            var newSize = image.Size.ResizeTo(size);

            var bitmap = new Bitmap(newSize.Width, newSize.Height);
            var g = Graphics.FromImage(bitmap);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            g.DrawImage(image, 0, 0, newSize.Width, newSize.Height);
            g.Dispose();
            return bitmap;
        }
        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="image"></param>
        /// <param name="path"></param>
        public static void SaveInFormat(this Image image, string path)
        {
            image.Save(path, Path.GetExtension(path).GetImageFormat());
        }

        public static void SaveToFileInQuality(this Image image, string path, ImageFormat format)
        {
            var parameters = new EncoderParameters();
            parameters.Param[0] = new EncoderParameter(Encoder.Quality, new long[] { 90 });
            var encoder = ImageCodecInfo.GetImageEncoders().First(x => x.FormatID == format.Guid);
            image.Save(path, encoder, parameters);
        }
        /// <summary>
        /// 居中剪裁
        /// </summary>
        /// <param name="image"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public static Image CropCenter(this Image image, int width)
        {
            Size newSize;
            if (image.Size.Height > image.Size.Width)
            {
                newSize = new Size(width, width * image.Size.Height / image.Size.Width);
            }
            else
            {
                newSize = new Size(width * image.Size.Width / image.Size.Height, width);
            }
            var bitmap = new Bitmap(width, width);

            var g = Graphics.FromImage(bitmap);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            g.DrawImage(image, (width - newSize.Width) / 2, (width - newSize.Height) / 2, newSize.Width, newSize.Height);
            g.Dispose();
            return bitmap;
        }
        /// <summary>
        /// 验证是否图片格式
        /// </summary>
        public static bool ValidImgExt(this HttpPostedFileBase file)
        {
            if (file == null || file.InputStream == null || file.InputStream.Length > maxSize)
            {
                return false;
            }
            string fileExt = Path.GetExtension(file.FileName).ToLower();
            if (fileExt == ".png" || fileExt == ".jpg" || fileExt == ".jpeg" || fileExt == ".gif" || fileExt == ".bmg")
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 保存图片 3种尺寸400*400 200*200 原尺寸，小于该尺寸则不压缩，保存在数据库的为400尺寸的路径。
        /// </summary>
        /// <param name="image"></param>
        public static string SaveImg(this Image image,string ext)
        {
            var date = DateTime.Now;
            string name = Guid.NewGuid().ToString().ToLower()+ ext;
            string FullPath = HttpContext.Current.Server.MapPath($@"{RootPath}/{date.Year}/{date.Month}/");
            if (!Directory.Exists(FullPath))//创建文件夹
                Directory.CreateDirectory(FullPath);
            Image file400X400 = image.ToSize(new Size { Height = 400, Width = 400 });
            Image file200X200 = image.ToSize(new Size { Height = 200, Width = 200 });
            file400X400.Save($"{FullPath}/{p400X400 + name}");
            file200X200.Save($"{FullPath}/{p200X200 + name}");
            image.Save($"{FullPath}/{p100 + name}");
            return $@"{RootPath}/{date.Year}/{date.Month}/{p400X400 + name}";
        }
    }
}
