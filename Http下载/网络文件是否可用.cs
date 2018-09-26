using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Http下载
{
    public class 网络文件是否可用
    {
        public static bool run(string url)
        {
            bool result = false;//下载结果

            WebResponse response = null;
            try
            {
                WebRequest req = WebRequest.Create(url);

                response = req.GetResponse();

                result = response == null ? false : true;

            }
            catch (WebException ex)
            {
                result = false;
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
            }

            return result;
        }
    }
}
