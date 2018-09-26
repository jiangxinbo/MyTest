using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace _12306
{
    class Program
    {
        static int w = 0;
        static void Main(string[] args)
        {
            var name = "郑州东";
            var cc = "g70";
            var cxlx = 1;//0 到达   1 出发
            var rq = "2018-06-06";
            string url = "http://dynamic.12306.cn/mapping/kfxt/zwdcx/LCZWD/from2.jsp?cz={0}&cc={1}&cxlx={2}&rq={3}&czEn={4}&tp={5}";
            var cz = HttpUtility.UrlEncode(name, Encoding.GetEncoding("utf-8"));
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            var tp = Convert.ToInt64(ts.TotalSeconds).ToString();
            var czEn = cz.Replace("%", "-").ToUpper();
            url = string.Format(url, cz, cc, cxlx, rq, czEn, tp);
            string html = new HttpManager().GetTorrentHtml(url);
            Console.WriteLine(html);
            string url2 = "http://dynamic.12306.cn/mapping/kfxt/zwdcx/LCZWD/cx.jsp?cz={0}&cc={1}&cxlx={2}&rq={3}&czEn={4}&tp={5}";
            url2 = string.Format(url2, cz, cc, cxlx, rq, czEn, tp);
            string html2 = new HttpManager().GetTorrentHtml(url2);
            Console.WriteLine(html2);



            //for (int j = 1; j <= 50; j++)
            //{
            //    for (int k = 0; k < 10; k++)
            //    {
            //        for (int i = 1; i <= 6; i++)
            //        {
            //            run(j, i);
            //        }
            //    }

            //}


            Console.ReadKey();








        }


        public static void  run(int j,int i)
        {
            Task.Factory.StartNew(() =>
            {
                var jsonstr = new HttpManager().GetTorrentHtml(string.Format("http://zx.meet.aodirock.com/v1/test/addwallet?userid={0}&currency_id={1}&valuta_str=1", j, i));
                var obj = JsonConvert.DeserializeObject<dynamic>(jsonstr);
                if (obj.data.error==0)
                    Console.WriteLine(++w + "  valuta = " + obj.data.data.valuta);
                else
                    Console.WriteLine(++w + "  valuta = " + obj.data.error_msg);


            });
        }

    }
}
