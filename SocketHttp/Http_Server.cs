using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketHttp
{
    public static class Http_Server
    {
        private static Socket _socket;

        static Http_Server()
        {
            _socket=new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);  //侦听socket
        }

        public static  void init()
        {
            _socket.Bind(new IPEndPoint(IPAddress.Any, 8081));
            _socket.Listen(100);
            _socket.BeginAccept(new AsyncCallback(OnAccept), _socket);  //开始接收来自浏览器的http请求（其实是socket连接请求）
            Console.Read();
        }

        static void OnAccept(IAsyncResult ar)
        {
            try
            {
                Socket socket = ar.AsyncState as Socket;
                Socket new_client = socket.EndAccept(ar);  //接收到来自浏览器的代理socket
                //NO.1  并行处理http请求
                socket.BeginAccept(new AsyncCallback(OnAccept), socket); //开始下一次http请求接收   （此行代码放在NO.2处时，就是串行处理http请求，前一次处理过程会阻塞下一次请求处理）

                byte[] recv_buffer = new byte[1024 * 640];
                int real_recv = new_client.Receive(recv_buffer);  //接收浏览器的请求数据
                string recv_request = Encoding.UTF8.GetString(recv_buffer, 0, real_recv);
                Console.WriteLine(recv_request);  //将请求显示到界面
                Resolve(recv_request, new_client);  //解析、路由、处理
                //NO.2  串行处理http请求
            }
            catch
            {

            }
        }

        /// <summary>
        /// 按照HTTP协议格式 解析浏览器发送的请求字符串
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        static void Resolve(string request, Socket response)
        {
            //浏览器发送的请求字符串request格式类似这样：
            //GET /?name=2&title=%E6%88%91 HTTP/1.1\r\n
            //Host: localhost: 8081\r\n
            //Connection: keep - alive\r\n
            //User - Agent: Mozilla / 5.0(Windows NT 10.0; WOW64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 63.0.3239.132 Safari / 537.36\r\n
            //Accept: image / webp,image / apng,image/*,*/*; q = 0.8\r\n
            //Referer: http://localhost:8081/\r\n
            //Accept - Encoding: gzip, deflate, br\r\n
            //Accept - Language: zh - CN,zh; q = 0.9,en; q = 0.8\r\n\r\n
            //id=123&pass=123       （post方式提交的表单数据，get方式提交数据直接在url中）

            string[] strs = request.Split(new string[] { "\r\n" }, StringSplitOptions.None);  //以“换行”作为切分标志
            if (strs.Length > 0)  //解析出请求路径、post传递的参数(get方式传递参数直接从url中解析)
            {
                string[] items = strs[0].Split(' ');  //items[1]表示请求url中的路径部分（不含主机部分）
                Dictionary<string, string> param = new Dictionary<string, string>();

                if (strs.Contains(""))  //包含空行  说明存在post数据
                {
                    string post_data = strs[strs.Length - 1]; //最后一项
                    if (post_data != "")
                    {
                        string[] post_datas = post_data.Split('&');
                        foreach (string s in post_datas)
                        {
                            param.Add(s.Split('=')[0], s.Split('=')[1]);
                        }
                    }
                }
                Route(items[1], param, response);  //路由处理
            }
        }


        /// <summary>
        /// 按照请求路径（不包括主机部分）  进行路由处理
        /// </summary>
        /// <param name="path"></param>
        /// <param name="param"></param>
        /// <param name="response"></param>
        static void Route(string path, Dictionary<string, string> param, Socket response)
        {
            if (path.EndsWith("index.html") || path.EndsWith("/"))  //请求首页
            {
                Home.HomePage(response);
            }
            else if (path.EndsWith("login.zsp"))  //登录 处理页面
            {
                User.LoginCheck(param["id"], param["pass"], response);
            }
            //...
        }



        #region 处理请求 并按照HTTP协议格式发送数据到浏览器
        /// <summary>
        /// 请求首页
        /// </summary>
        class Home
        {
            public static void HomePage(Socket response)
            {
                string statusline = "HTTP/1.1 200 OK\r\n";   //状态行
                byte[] statusline_to_bytes = Encoding.UTF8.GetBytes(statusline);

                string content =
                "<html>" +
                    "<head>" +
                        "<title>socket webServer  -- Login</title>" +
                    "</head>" +
                    "<body>" +
                       "<div style=\"text-align:center\">" +
                           "<form method=\"post\" action=\"/login.zsp\">" +
                               "用户名:&nbsp;<input name=\"id\" /><br />" +
                               "密码:&nbsp;&nbsp;&nbsp;<input name=\"pass\" type=\"password\"/><br />" +
                               "<input  type=\"submit\" value=\"登录\"/>" +
                           "</form>" +
                       "</div>" +
                    "</body>" +
                "</html>";  //内容
                byte[] content_to_bytes = Encoding.UTF8.GetBytes(content);

                string header = string.Format("Content-Type:text/html;charset=UTF-8\r\nContent-Length:{0}\r\n", content_to_bytes.Length);
                byte[] header_to_bytes = Encoding.UTF8.GetBytes(header);  //应答头

                response.Send(statusline_to_bytes);  //发送状态行
                response.Send(header_to_bytes);  //发送应答头
                response.Send(new byte[] { (byte)'\r', (byte)'\n' });  //发送空行
                response.Send(content_to_bytes);  //发送正文（html）

                response.Close();
            }
            //...
        }

        /// <summary>
        /// 登录(post方式提交表单)  
        /// </summary>
        class User
        {
            public static void LoginCheck(string name, string pass, Socket response)
            {
                //访问数据库，检查用户名密码是否正确（此处略）...
                //假设用户名密码正确  返回登录成功页面

                //System.Threading.Thread.Sleep(10000);  //模拟耗时处理

                string statusline = "HTTP/1.1 200 OK\r\n";   //状态行
                byte[] statusline_to_bytes = Encoding.UTF8.GetBytes(statusline);

                string content =
                "<html>" +
                    "<head>" +
                        "<title>socket webServer  -- Login</title>" +
                    "</head>" +
                    "<body>" +
                       "<div style=\"text-align:center\">" +
                           "欢迎您！" + name + ",今天是 " + DateTime.Now.ToLongDateString() +
                       "</div>" +
                    "</body>" +
                "</html>";  //内容
                byte[] content_to_bytes = Encoding.UTF8.GetBytes(content);

                string header = string.Format("Content-Type:text/html;charset=UTF-8\r\nContent-Length:{0}\r\n", content_to_bytes.Length);
                byte[] header_to_bytes = Encoding.UTF8.GetBytes(header);  //应答头

                response.Send(statusline_to_bytes);  //发送状态行
                response.Send(header_to_bytes);  //发送应答头
                response.Send(new byte[] { (byte)'\r', (byte)'\n' });  //发送空行
                response.Send(content_to_bytes);  //发送正文（html）

                response.Close();
            }
            //...
        }
        #endregion

    }
}
