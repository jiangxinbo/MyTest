using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace 小说Txt下载
{
    //定义委托
    public delegate void delegateProgress(long totalcount, long readcount, int currentreadcount);


    public class DownLoadFile
    {
        //public delegateProgress onprogress;
        public event delegateProgress onProgress;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="saveFileName">服务器保存文件路径+文件名+后缀</param>
        /// <param name="downurl">下载地址</param>
        /// <returns></returns>
        public bool DownloadFile(string saveFileName, string downurl)
        {
            string directory = Path.GetDirectoryName(saveFileName);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            bool flag = false;
            //打开上次下载的文件
            long SPosition = 0;
            //实例化流对象
            FileStream FStream;
            //判断要下载的文件夹是否存在
            if (File.Exists(saveFileName))
            {
                //打开要下载的文件
                FStream = File.OpenWrite(saveFileName);
                //获取已经下载的长度
                SPosition = FStream.Length;
                FStream.Seek(SPosition, SeekOrigin.Current);
            }
            else
            {
                //文件不保存创建一个文件
                FStream = new FileStream(saveFileName, FileMode.Create);
                SPosition = 0;
            }
            try
            {
                //打开网络连接
                HttpWebRequest myRequest = (HttpWebRequest)HttpWebRequest.Create(downurl);
                if (SPosition > 0) myRequest.AddRange((int)SPosition);             //设置Range值
                //向服务器请求,获得服务器的回应数据流
                var response = myRequest.GetResponse();
                var ct = response.ContentType;

                var ss = response.Headers;
                long zongcount = Convert.ToInt64(response.Headers.Get("Content-Length")) + SPosition;
                zongcount = response.ContentLength + SPosition;
                Stream myStream = response.GetResponseStream();
                //定义一个字节数据
                byte[] btContent = new byte[1024 * 10];
                int intSize = 0;
                intSize = myStream.Read(btContent, 0, btContent.Length);

                long readcount = SPosition;
                readcount += intSize;
                while (intSize > 0)
                {
                    FStream.Write(btContent, 0, intSize);
                    onProgress(zongcount, readcount, intSize);
                    intSize = myStream.Read(btContent, 0, btContent.Length);
                    readcount += intSize;


                }
                //关闭流
                FStream.Close();
                myStream.Close();
                flag = true;        //返回true下载成功
            }
            catch (Exception)
            {
                FStream.Close();
                flag = false;       //返回false下载失败
            }
            return flag;
        }




    }
}
