using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;

namespace SocketHttp
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

           





            var data="";
            var client = new Http_Client();
            var sm= client.get("https://cl.k6j9.icu/codeform.php");
            var htmlbyte = new byte[sm.Length];
            sm.Read(htmlbyte, 0, htmlbyte.Length);
            var html = Encoding.GetEncoding(client.HttpHeaders.Charset).GetString(htmlbyte);
            client.printcookies();
            Console.WriteLine(html);
            Console.WriteLine();

            

            client = client.getNew();
            sm = client.get("https://cl.k6j9.icu/require/codeimg.php", referer: "https://cl.k6j9.icu/codeform.php");
            Image img = Image.FromStream(sm);
            img.Save("a://code.jpg");
            client.printcookies();

            var code=Console.ReadLine();
            data = "validate=" + code;
            client = client.getNew();
            sm = client.get("https://cl.k6j9.icu/codeform.php",method:"POST", datainfo:data, referer: "https://cl.k6j9.icu/codeform.php");
            client.printcookies();
            htmlbyte = new byte[sm.Length];
            sm.Read(htmlbyte, 0, htmlbyte.Length);
            html = Encoding.GetEncoding(client.HttpHeaders.Charset).GetString(htmlbyte);
            Console.WriteLine(html);
            //html = Encoding.GetEncoding("utf-8").GetString(htmlbyte);
            //Console.WriteLine(html);
            //Console.WriteLine();

            client = client.getNew();
            sm = client.get("https://cl.k6j9.icu/notice.php", referer: "https://cl.k6j9.icu/codeform.php");
            client.printcookies();
            htmlbyte = new byte[sm.Length];
            sm.Read(htmlbyte, 0, htmlbyte.Length);
            html = Encoding.GetEncoding(client.HttpHeaders.Charset).GetString(htmlbyte);
            Console.WriteLine(html);

            client = client.getNew();
            sm = client.get("https://cl.k6j9.icu/thread0806.php?fid=2");
            client.printcookies();
            htmlbyte = new byte[sm.Length];
            sm.Read(htmlbyte, 0, htmlbyte.Length);
            html = Encoding.GetEncoding(client.HttpHeaders.Charset).GetString(htmlbyte);
            Console.WriteLine(html);

            Console.ReadLine();

            Console.WriteLine("Hello World!");
        }
    }
}
