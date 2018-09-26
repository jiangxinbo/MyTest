using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Http下载
{
    public class Http
    {
        private CookieContainer cc = new CookieContainer();
        /// <summary>
        /// 记录数量
        /// </summary>
        int recordCount = 0;
        private string userAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
        int taskid = 0;

        public Http(string url)
        {
            GetTorrent(url);
        }



        







        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受  
        }



        public string GetTorrent(string url)
        {
            string html = null;
            html = GetTorrentHtml(url);

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            string newurl = null;
            string directory_path = null;
            string file_bt_path = null;
            string file_bt_path_tmp = null;
            try
            {
                HtmlNode paramRef = doc.DocumentNode.SelectSingleNode("//input[@name='ref']");
                string p_ref = paramRef.GetAttributeValue("Value", null);
                HtmlNode paramReff = doc.DocumentNode.SelectSingleNode("//input[@name='reff']");
                string p_reff = paramReff.GetAttributeValue("Value", null);
                newurl = string.Format("http://www.rmdown.com/download.php?ref={0}&reff={1}", p_ref, p_reff);
                string filename = "【{1}】❤{2}❤〓{3}";
                filename = filename.Replace("\\", "-");
                filename = filename.Replace("*", "-");
                filename = filename.Replace("/", "-");
                filename = filename.Replace(":", "-");
                filename = filename.Replace("?", "-");
                filename = filename.Replace("<", "-");
                filename = filename.Replace(">", "-");
                filename = filename.Replace("|", "-");
                directory_path = @"A:\torrent";//目录地址
                file_bt_path = string.Format(@"{0}\{1}.torrent", directory_path, filename);
                file_bt_path_tmp = string.Format(@"{0}\{1}.tmp", directory_path, filename);
                if (File.Exists(file_bt_path_tmp))
                {
                    File.Delete(file_bt_path_tmp);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetTorrent({0}) html解析错误");
                return null;
            }
            if (!File.Exists(file_bt_path))
            {
                return GetFile(newurl, directory_path, file_bt_path, file_bt_path_tmp);
            }
            return file_bt_path;
        }

        /// <summary>
        /// 请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="postMethod">是否是post请求,默认get请求,true:post请求,false:get请求</param>
        /// <param name="parameters">post请求参数</param>
        /// <param name="requestEncoding">请求编码,默认为utf8</param>
        /// <param name="timeout">默认超时时间60秒</param>
        /// <returns>返回网页数据</returns>
        public string GetFile(string url, string directory_path, string file_bt_path, string file_bt_path_tmp, int timeout = 60)
        {
            Console.Write("#");
            System.GC.Collect();
            //设置最大连接数
            ServicePointManager.DefaultConnectionLimit = 5000;
            //是否下载完成
            bool flag = false;
            //打开上次下载的文件
            //long SPosition = 0;
            //实例化流对象
            FileStream FStream = null;
            try
            {
                if (!Directory.Exists(directory_path))
                {
                    Directory.CreateDirectory(directory_path);
                }
                //判断要下载的文件夹是否存在
                if (File.Exists(file_bt_path_tmp))
                {
                    File.Delete(file_bt_path_tmp);
                    ////打开要下载的文件
                    //FStream = File.OpenWrite(file_bt_path_tmp);
                    ////获取已经下载的长度
                    //SPosition = FStream.Length;
                    //FStream.Seek(SPosition, SeekOrigin.Current);
                    FStream = new FileStream(file_bt_path_tmp, FileMode.Create);
                    //SPosition = 0;
                }
                else
                {
                    FStream = new FileStream(file_bt_path_tmp, FileMode.Create);
                    //SPosition = 0;
                }
            }
            catch (Exception ee)
            {
                Console.WriteLine("GetFile({0}) 文件操作错误{1}", url, file_bt_path_tmp);
                return null;
            }
            Console.Write("开始下载文件");
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            //请求url以获取数据
            try
            {


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
                //if (SPosition > 0)
                //{
                //    request.AddRange((int)SPosition); //设置Range值
                //}
                request.Timeout = timeout * 1000;
                request.ReadWriteTimeout = timeout * 1000;
                request.ContinueTimeout = timeout * 1000;
                request.Referer = "http://www.viidii.info/?http://www______rmdown______com/link______php?hash=1712f854535ce0184529d410e8f12eddc14d6f9aacd&z";
                if (request.CookieContainer == null)
                {
                    request.CookieContainer = cc;
                }
                request.UserAgent = userAgent;
                request.ContentType = "application/x-www-form-urlencoded";
                request.KeepAlive = true;
                request.Method = "get";
                //获取服务器返回
                response = (HttpWebResponse)request.GetResponse();
                Console.WriteLine("#1");
                Console.WriteLine(response.ContentLength / 1024);
                //获取HTTP返回数据
                using (Stream myStream = response.GetResponseStream())
                {
                    //定义一个字节数据
                    byte[] btContent = new byte[1024];
                    int intSize = 0;
                    Console.WriteLine("#2");
                    intSize = myStream.Read(btContent, 0, 1024);
                    long length = 0;
                    while (intSize > 0)
                    {
                        length += intSize;
                        Console.Write("!");
                        FStream.Write(btContent, 0, intSize);
                        intSize = myStream.Read(btContent, 0, 1024);
                        Console.Write("^");
                    }
                    Console.WriteLine("#3   "+ length/1024);
                    //关闭流
                    FStream.Close();
                    myStream.Close();
                    flag = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("?" + e.Message);
                if (FStream != null)
                {
                    FStream.Close();
                }
                Console.WriteLine("?1");
                if (File.Exists(file_bt_path_tmp))
                {
                    File.Delete(file_bt_path_tmp);
                }
                Console.WriteLine(url + "* * * *" + e.Message);
                //关闭连接和流
                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
                flag = false;       //返回false下载失败

                //Thread.Sleep(1000 * 10);
                //return GetFile(url, directory_path,file_bt_path, file_bt_path_tmp, timeout);
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
            Console.WriteLine("#4");
            if (File.Exists(file_bt_path_tmp))
            {
                try
                {
                    File.Move(file_bt_path_tmp, file_bt_path);
                }
                catch (Exception ex)
                {
                    if (File.Exists(file_bt_path_tmp))
                    {
                        File.Delete(file_bt_path_tmp);
                    }
                    else
                    {
                        Console.WriteLine("种子文件移动错误！----------------{0}", ex);
                    }
                }
            }
            Console.WriteLine("#5");
            if (flag)
            {
                if (File.Exists(file_bt_path_tmp))
                {
                    try
                    {
                        File.Move(file_bt_path_tmp, file_bt_path);
                    }
                    catch (Exception ex)
                    {
                        if (File.Exists(file_bt_path_tmp))
                        {
                            File.Delete(file_bt_path_tmp);
                        }
                        else
                        {
                            Console.WriteLine("种子文件移动错误！----------------", ex);
                        }
                    }
                }
                return file_bt_path;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url">downloadurl</param>
        /// <param name="pw"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public string GetTorrentHtml(string url,  int timeout = 60)
        {
            System.GC.Collect();
            string hash = null;
            try
            {
                hash = url.Substring(url.IndexOf("hash="));
                hash = hash.Replace("<", "");
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetTorrentHtml() id={0} ,hash解析错误");
                return null;
            }
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
                request.Referer = string.Format("http://www.viidii.info/?http://www______rmdown______com/link______php?{0}&z", hash);
                if (request.CookieContainer == null)
                {
                    request.CookieContainer = cc;
                }
                request.UserAgent = userAgent;
                request.ContentType = "application/x-www-form-urlencoded";
                //request.AllowWriteStreamBuffering = false;
                //启用页面压缩技术
                //request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");
                request.KeepAlive = true;
                request.Method = "get";
                //获取服务器返回
                response = (HttpWebResponse)request.GetResponse();
                //获取HTTP返回数据
                using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("GB2312")))
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



        
    }
}
