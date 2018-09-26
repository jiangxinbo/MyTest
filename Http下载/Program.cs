using System;
using System.Text;

namespace Http下载
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var result=网络文件是否可用.run("http://imgme.me/images/2017/01/02/um2017-0106-45-1.jpg");
            Console.WriteLine(result);
            Console.Read();





    }
    }
}
