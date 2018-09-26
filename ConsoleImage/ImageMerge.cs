using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace ConsoleImage
{
    public class ImageMerge
    {
        /// <summary>
        /// 合并图片
        /// </summary>
        /// <param name="streams">图片列表</param>
        /// <returns>Stream</returns>
        public static MemoryStream Merge(List<Stream> streams,long zhiliang=100)
        {
            List<Image> imglist = new List<Image>();
            int maxWidth = 0;
            foreach (var streamitem in streams)
            {
                Image img = Image.FromStream(streamitem);
                maxWidth = maxWidth < img.Width ? img.Width : maxWidth;
                imglist.Add(img);
            }
            int drawX = 0;//绘图高度
            int drawY = 0;//绘图宽度
            int rowheight = 0; //当前行高
            foreach (var item in imglist)
            {
                if (drawX + item.Width <= maxWidth)
                {
                    drawX += item.Width;
                    if (item.Height > rowheight)
                        rowheight = item.Height;
                }
                else
                {
                    drawY = rowheight;
                    rowheight += item.Height;
                    drawX = item.Width;
                }
            }
            Bitmap b = new Bitmap(maxWidth, rowheight);
            var g = Graphics.FromImage(b);
            g.InterpolationMode = InterpolationMode.High;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;

            drawX = 0;//绘图高度
            drawY = 0;//绘图宽度
            rowheight = 0; //当前最大行高
            foreach (var item in imglist)
            {
                if (drawX + item.Width <= maxWidth)
                {
                    //g.DrawImage(item, drawX, drawY, item.Width, item.Height);
                    g.DrawImageUnscaled(item, drawX, drawY, item.Width, item.Height);
                    drawX += item.Width;
                    if (item.Height > rowheight)
                        rowheight = item.Height;
                }
                else
                {
                    drawY = rowheight;
                    rowheight += item.Height;
                    drawX = 0;
                    g.DrawImage(item, drawX, drawY, item.Width, item.Height);
                    drawX += item.Width;
                }
            }
            var myImageCodecInfo = GetEncoderInfo("image/jpeg");
            // 基于GUID创建一个Encoder对象
            //用于Quality参数类别。
            var myEncoder = Encoder.Quality;

            //创建一个EncoderParameters对象。
            // EncoderParameters对象有一个EncoderParameter数组
            //对象 在这种情况下，只有一个
            //数组中的EncoderParameter对象。
            var myEncoderParameters = new EncoderParameters(1);
            //将位图保存为质量级别为100的JPEG文件。
            var myEncoderParameter = new EncoderParameter(myEncoder, zhiliang);
            myEncoderParameters.Param[0] = myEncoderParameter;
            MemoryStream stream = new MemoryStream();
            b.Save(stream, myImageCodecInfo, myEncoderParameters);
            b.Dispose();
            g.Dispose();
            return stream;
        }
        private static  ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
    }
}
