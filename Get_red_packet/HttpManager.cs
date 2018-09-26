using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Get_red_packet
{
    public class HttpManager
    {
        private CookieContainer cc = new CookieContainer();
        /// <summary>
        /// 记录数量
        /// </summary>
        int recordCount = 0;
        private string userAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";

        public string GetHtml(string url, int timeout = 60)
        {
            System.GC.Collect();

            string result = null;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            //请求url以获取数据
            try
            {
                //设置最大连接数
                ServicePointManager.DefaultConnectionLimit = 5000;
                //如果是发送HTTPS请求  
                if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                    request = WebRequest.Create(url) as HttpWebRequest;
                    request.ProtocolVersion = HttpVersion.Version10;
                }
                else
                {
                    request = (HttpWebRequest)WebRequest.Create(url);
                }
                request.Timeout = timeout * 1000;
                request.ReadWriteTimeout = timeout * 1000;
                request.ContinueTimeout = timeout * 1000;
                request.Referer = "http://dynamic.12306.cn/mapping/kfxt/zwdcx/LCZWD/CCCX.jsp";


                if (request.CookieContainer == null)
                {
                    request.CookieContainer = cc;
                }
                request.UserAgent = userAgent;
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers.Add("X-Forwarded-For", "122.120.10.11");
                //request.AllowWriteStreamBuffering = false;
                //启用页面压缩技术
                //request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");
                request.KeepAlive = true;
                request.Method = "get";
                //获取服务器返回
                response = (HttpWebResponse)request.GetResponse();
                //获取HTTP返回数据
                using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8)) // Encoding.GetEncoding("gb2312")))
                {
                    result = sr.ReadToEnd().Trim();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("GetTorrentHtml()   url:{0}  url长度:{1}", url, url.Length);

                //关闭连接和流
                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
            }
            //关闭连接和流
            if (response != null)
            {
                response.Close();
            }
            if (request != null)
            {
                request.Abort();
            }
            return result;
        }
        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受  
        }
    }
}
