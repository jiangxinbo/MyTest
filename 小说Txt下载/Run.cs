using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace 小说Txt下载
{
    class Run
    {
        static void Main(string[] args)
        {
            HtmlHelp hh = new HtmlHelp();
            //hh.init("http://www.biquge5200.com/52_52542/");
            hh.downfile("龙王传说");
            //down("https://ss1.baidu.com/6ONXsjip0QIZ8tyhnq/it/u=476992237,171850210&fm=58&u_exp_0=4204925918,41335");


            Console.ReadKey();
        }

        static void down(string downurl)
        {
            DownLoadFile df = new DownLoadFile();
            df.onProgress += Df_onProgress; ;
            string filename = Path.GetFileName(downurl);
            string localFile = string.Format(@"c:\books\{0}.downloading", filename);
            var flg = df.DownloadFile(localFile, downurl);
            if (flg)
            {
                string newfilename = string.Format(@"c:\books\{0}", filename);
                if (File.Exists(newfilename))
                {
                    File.Delete(newfilename);
                }
                File.Move(localFile, newfilename);
            }
        }

        private static void Df_onProgress(long totalcount, long readcount, int current)
        {
            Console.WriteLine(string.Format("{0}已下载：{1}  {2}  已下载字节数:{3}      {4}", totalcount, (readcount / Convert.ToDouble(totalcount)).ToString("0.00%"), HtmlHelp.ByteConversionGBMBKB(readcount), readcount, current));
            if (totalcount == readcount)
            {
                Console.WriteLine("下载完毕");
            }
        }
    }
}
