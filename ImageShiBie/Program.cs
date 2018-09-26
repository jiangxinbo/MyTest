using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;

namespace ImageShiBie
{
    class Program
    {
        static void Main(string[] args)
        {
            var img = new Bitmap("");
            var te = new TesseractEngine("./tessdata", "eng", EngineMode.TesseractAndCube);
            var page = te.Process(img);
            Console.WriteLine(page);

        }
    }
}
