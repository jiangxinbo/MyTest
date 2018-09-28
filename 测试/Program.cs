using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tool;
using static System.Net.Mime.MediaTypeNames;

namespace 测试
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            while (true)
            {
                var a = DateTime.Parse("2018-09-27 19:54");
                var b = a - DateTime.Now;
                Console.WriteLine("还有、 {0}天,{1}小时，{2}分钟,{3}秒 到家", b.Days, b.Hours, b.Minutes, b.Seconds);
                Thread.Sleep(1000);
                Console.Clear();
            }
            
           
            Console.WriteLine("Ok!");
            Console.Read();

            


        

    }
    }
}
