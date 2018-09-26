using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace SocketHttp
{
    public  class Http_Client
    {
        private  Socket _socket;
        private bool isHttps = false;
        public Http_Client()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public Stream get(string url, string datainfo = null, string method = "get", string charset = "UTF-8", string referer = null)
        {
            try
            {
                return init(url, datainfo, method, charset, referer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                
            }
            
        }

        private  Stream init(string url,string datainfo=null,string method="get", string charset = "UTF-8",string referer=null)
        {
            var coding = Encoding.GetEncoding(charset);
            byte[] dataByte = null;
            if(datainfo!=null)
                dataByte = coding.GetBytes(datainfo);
            Uri uri = new Uri(url);
            _socket.Connect(uri.Host, uri.Port);
            MemoryStream ms = new MemoryStream();
            if (referer == null) referer = url;
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("{0} {1} HTTP/1.1\r\n", method.ToUpper(), uri.PathAndQuery));
            sb.Append(string.Format("Host: {0}\r\n", uri.Authority));
            sb.Append("Connection: keep - alive\r\n");
            sb.Append("User - Agent: Mozilla / 5.0(Windows NT 10.0; WOW64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 63.0.3239.132 Safari / 537.36\r\n");
            sb.Append(string.Format("Accept: image / webp,image / apng,image/*,*/*; q = 0.8\r\n"));
            sb.Append(string.Format("Referer: {0}\r\n",referer));
            sb.Append(string.Format("Accept - Encoding: gzip, deflate, br\r\n"));
            if(datainfo!=null)
                sb.Append(string.Format("Content-Length:{0}\r\n", dataByte.Length));
            sb.Append(string.Format("Accept - Language: zh - CN,zh; q = 0.9,en; q = 0.8\r\n"));
            sb.Append(string.Format("\r\n"));
            var sendinfo = sb.ToString();
            _socket.ReceiveTimeout = 1000*100;
            _socket.SendTimeout = 1000 * 100;

            SslStream ssl = null;
            isHttps = string.Compare(uri.Scheme, "https", false) == 0;
            if (isHttps)
            {
                ssl = new SslStream(new NetworkStream(_socket), false, delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) {
                    return sslPolicyErrors == SslPolicyErrors.None;
                }, null);
                ssl.AuthenticateAsClient(uri.Host);
                ssl.Write(coding.GetBytes(sendinfo));
                if (datainfo != null)
                    ssl.Write(dataByte);
            }
            else
            {
                var result_int = _socket.Send(coding.GetBytes(sendinfo));
                if (datainfo != null)
                    result_int = _socket.Send(dataByte);
            }
            string headertext = "";
            int body = 0;
            MemoryStream response = new MemoryStream();
            MemoryStream img = new MemoryStream();
            bool flat = true;
            int headLengh = 0;
            while (true)
            {
                byte[] data = new byte[102400];
                //接收一个字节
                int rece = 0;
                if (isHttps)
                {
                    rece = ssl.Read(data, 0, data.Length);
                }
                else
                {
                    rece = _socket.Receive(data, data.Length, SocketFlags.None);
                }
                if (rece == 0)
                {
                    response.Position = 0;
                    byte[] bset = new byte[response.Length];
                    response.Read(bset, 0, bset.Length);

                    var msg = Encoding.UTF8.GetString(bset);
                }
                response.Write(data, 0, rece);
                string recv_request = Encoding.UTF8.GetString(data, 0, rece);
                headertext += recv_request;
                if(flat)
                {
                    if (headertext.IndexOf("\r\n\r\n") > 0)
                    {
                        headLengh = Encoding.UTF8.GetBytes(headertext.Substring(0, headertext.IndexOf("\r\n\r\n") + 1 + "\r\n\r\n".Length)).Length - 3;
                        string content = "CONTENT-LENGTH:";
                        int start = headertext.ToUpper().IndexOf(content);
                        if (start == -1) continue;
                        headertext = headertext.Substring(start + content.Length);
                        int end = headertext.IndexOf("\r\n");
                        body = int.Parse(headertext.Substring(0, end)); //包体长度
                        flat = false;
                    }
                }
                else
                {
                    var t = headLengh + body;
                    if (response.Length == t)
                    {
                        response.Position = 0;
                        byte[] bset = new byte[response.Length];
                        response.Read(bset, 0, bset.Length);
                        var msg = Encoding.UTF8.GetString(bset);
                        byte[] rs = new byte[body];
                        Array.Copy(bset, headLengh, rs, 0, body);
                        return new MemoryStream(rs);
                    }
                    if (response.Length > t)
                        break;
                }

            }
            return response;

            
        }

        



      


    }
}
