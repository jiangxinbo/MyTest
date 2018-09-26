using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace ConsoleImage
{
    class Program
    {
        static void Main(string[] args)
        {
            ImageCodecInfo ici = null;
            var encoders = ImageCodecInfo.GetImageEncoders();
            for (int j = 0; j < encoders.Length; ++j)
            {
                var item = encoders[j];
                if(item.FilenameExtension.ToLower().IndexOf(".jpg".ToLower())>=0)
                {
                    ici = item;
                    break;
                }
                
            }


     








            Console.WriteLine("Hello World!");
        }

        
    }
}
