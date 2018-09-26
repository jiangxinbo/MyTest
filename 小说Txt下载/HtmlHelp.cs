using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace 小说Txt下载
{
    public class HtmlHelp
    {


        private CookieContainer cc = new CookieContainer();
        private string userAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";

        public HtmlHelp()
        {

        }

        public string Post(string url, int timeout = 30)
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
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = timeout * 1000;
                request.ReadWriteTimeout = timeout * 1000;
                request.ContinueTimeout = timeout * 1000;
                if (request.CookieContainer == null)
                {
                    request.CookieContainer = cc;
                }
                request.UserAgent = userAgent;
                request.ContentType = "application/x-www-form-urlencoded";
                //request.AllowWriteStreamBuffering = false;
                request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");
                request.KeepAlive = true;
                request.Method = "get";



                //获取服务器返回
                response = (HttpWebResponse)request.GetResponse();
                string contentype = response.Headers["Content-Type"];
                Regex regex = new Regex("charset\\s*=\\s*[\\W]?\\s*([\\w-]+)", RegexOptions.IgnoreCase);
                if (response.ContentEncoding.ToLower() == "gzip")//如果使用了GZip则先解压
                {
                    using (System.IO.Stream streamReceive = response.GetResponseStream())
                    {
                        using (var zipStream = new System.IO.Compression.GZipStream(streamReceive, System.IO.Compression.CompressionMode.Decompress))
                        {
                            if (regex.IsMatch(contentype))
                            {
                                Encoding ending = Encoding.GetEncoding(regex.Match(contentype).Groups[1].Value.Trim());
                                using (StreamReader sr = new System.IO.StreamReader(zipStream, ending))
                                {
                                    result = sr.ReadToEnd();
                                }
                            }
                            else
                            {
                                using (StreamReader sr = new System.IO.StreamReader(zipStream, Encoding.Default))
                                {
                                    result = sr.ReadToEnd();
                                }
                            }

                        }

                    }
                }
                else
                {
                    //获取HTTP返回数据
                    using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        result = sr.ReadToEnd().Trim();
                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
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
            return result;
        }


        public void init(string url)
        {
            string html = Post(url);
            if (html == null) return;
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            var bookname = doc.DocumentNode.SelectSingleNode("//div[@id='info']/h1[1]").InnerText;
            downfile(bookname);

            var sss = doc.DocumentNode.SelectSingleNode("//div[@id='list']").InnerHtml;
            var ss1 = doc.DocumentNode.SelectNodes("//div[@id='list']/dl/dt[2]");
            var ss3 = doc.DocumentNode.SelectNodes("//div[@id='list']/dl/dd[position()>9]");
            foreach (var item in ss3)
            {
                Console.WriteLine(item.InnerText);
            }
            Console.WriteLine("收工");
        }

        public void downfile(string bookname)
        {
            Task.Factory.StartNew(() =>
            {
                string url = "http://www.22ff.com/txt/" + bookname;
                string htmlstr = Post(url);
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(htmlstr);
                var neirong3a = doc.DocumentNode.SelectSingleNode("//li[@class='neirong3']/a");
                if (neirong3a == null)
                {
                    Console.WriteLine("没有找到" + bookname);
                }
                var neirong3avalue = neirong3a.Attributes["href"].Value;
                url = "http://www.22ff.com" + neirong3avalue;
                string extensionName = Path.GetExtension(url);
                htmlstr = Post(url);
                doc.LoadHtml(htmlstr);
                var downbookurl = doc.DocumentNode.SelectSingleNode("//div[@class='down_bar']/script").InnerHtml;
                downbookurl = downbookurl.Remove(0, downbookurl.IndexOf("http"));
                downbookurl = downbookurl.Remove(downbookurl.Length - 3);
                string localFile = string.Format(@"c:\books\{0}.downloading", bookname);
                DownLoadFile df = new DownLoadFile();
                df.onProgress += onProgress;
                var flg = df.DownloadFile(localFile, downbookurl);
                if (flg)
                {
                    string newfilename = string.Format(@"c:\books\{0}{1}", bookname, extensionName);
                    if (File.Exists(newfilename))
                    {
                        File.Delete(newfilename);
                    }
                    File.Move(localFile, newfilename);
                }
            });

        }

        private void onProgress(long totalcount, long readcount, int current)
        {
            Console.WriteLine(string.Format("{0}已下载：{1}  {2}  已下载字节数:{3}      {4}", totalcount, (readcount / Convert.ToDouble(totalcount)).ToString("0.00%"), ByteConversionGBMBKB(readcount), readcount, current));
            if (totalcount == readcount)
            {
                Console.WriteLine("下载完毕");
            }
        }

        const int GB = 1024 * 1024 * 1024;//定义GB的计算常量
        const int MB = 1024 * 1024;//定义MB的计算常量
        const int KB = 1024;//定义KB的计算常量
        public static string ByteConversionGBMBKB(Int64 KSize)
        {
            if (KSize / GB >= 1)//如果当前Byte的值大于等于1GB
                return (KSize / (float)GB).ToString("0.00") + "    GB";//将其转换成GB
            else if (KSize / MB >= 1)//如果当前Byte的值大于等于1MB
                return (KSize / (float)MB).ToString("0.00") + "    MB";//将其转换成MB
            else if (KSize / KB >= 1)//如果当前Byte的值大于等于1KB
                return (KSize / (float)KB).ToString("0.00") + "    KB";//将其转换成KGB
            else
                return KSize.ToString() + "    Byte";//显示Byte值
        }




    }
}
