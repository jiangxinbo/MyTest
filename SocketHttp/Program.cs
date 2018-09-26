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
            //WebClient wc = new WebClient();
            //var info=wc.DownloadString("http://weixin.sogou.com/weixin?type=1&s_from=input&query=%E8%8B%B1%E5%9B%BD%E7%BA%A2%E9%A2%86%E5%B7%BE&ie=utf8&_sug_=n&_sug_type_=");
            //Console.WriteLine(info);
            //Http_Server.init();
            var url = "http://img.zcool.cn/community/0117e2571b8b246ac72538120dd8a4.jpg@1280w_1l_2o_100sh.jpg";


            List<string> urls = new List<string>();
            urls.Add(url);
            url = "https://gss2.bdstatic.com/9fo3dSag_xI4khGkpoWK1HF6hhy/baike/c0%3Dbaike92%2C5%2C5%2C92%2C30/sign=3d92437a3cfae6cd18b9a3336eda6441/f7246b600c33874441418d31580fd9f9d62aa0f3.jpg";
            urls.Add(url);

            int i = 0;
            foreach(var item in urls)
            {
                var s = new Http_Client().get(item);
                Image img = Image.FromStream(s);
                img.Save(string.Format(@"C:\Users\007\Pictures\{0}.jpg",i));
                ++i;
            }
            
            Console.WriteLine("Hello World!");
        }
    }
}
