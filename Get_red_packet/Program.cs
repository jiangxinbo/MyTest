using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Get_red_packet
{
    class Program
    {
        static bool star = false;
        static int member = 2;
        static int count = 0;
        static void Main(string[] args)
        {

            string url = @"https://www.jinse.com/bitcoin/207091.html";
            HttpManager hm = new HttpManager();
            string jsonstr = hm.GetHtml(url);
            Console.WriteLine(jsonstr);
            Console.ReadKey();

            Console.Write("等待抢红包");
            while (!star)
            {
                Thread.Sleep(200);
                Console.Write(".");
                jiance();
            }
            Console.WriteLine("开始领取红包");



            Thread t = new Thread(run1);
            t.Start("Thread-1");

            

            Thread t1 = new Thread(run1);
            t1.Start("Thread-2");


            while (member != 0)
            {
                Task.Factory.StartNew(() =>
                {
                    run("Factory");
                });
            }



            Console.ReadKey();
        }



        static void jiance()
        {
            string url = @"http://zx.meet.aodirock.com/v1/api/c/c";
            HttpManager hm = new HttpManager();
            string jsonstr = hm.GetHtml(url);
            if (jsonstr == "1")
            {
                star = true;
            }
        }

        public static void run1(object str)
        {
            while (member != 0)
            {
                run(str.ToString());
            }
        }


        public static void run(string str)
        {
            string url = @"http://zx.meet.aodirock.com/v1/asset/receive_red_packet?rpid=2&member_id=18&access_token=eyJhbGciOiJIUzI1NiIsImV4cCI6MTUzMDYyOTg1NSwiaWF0IjoxNTI5OTA5ODU1fQ.eyJ1c2VyX2lkIjo0OTF9.82hSMsQbIfYPymG2zB9my11ucBJMQv0t8gbuiSZmXQ0";
            HttpManager hm = new HttpManager();
            string jsonstr = hm.GetHtml(url);
            var obj = JsonConvert.DeserializeObject<dynamic>(jsonstr);
            if (obj.error == 0)
            {
                if(member!=0)
                {
                    member = obj.data.remaining_member;
                }
                
                int ct=Interlocked.Increment(ref count);
                Console.WriteLine(string.Format("领取成功  线程:【{0,4}】   {1,6}    领取金额：{2}    代币名称：{3}    剩余红包数量：{4}    " + str, Thread.CurrentThread.ManagedThreadId,ct,obj.data.money,obj.data.name,obj.data.remaining_member));
            }
            else
            {
                switch (obj.data.state)
                {
                    case 1: Console.WriteLine("成员不存在"); break;
                    case 2: Console.WriteLine("红包不存在"); break;
                    case 3: Console.WriteLine("红包已过期"); break;
                    case 4: Console.WriteLine("红包已领取"); break;
                    case 5: Console.WriteLine("红包已领完"); break;
                    case 6: Console.WriteLine("正在拆红包，请稍等");
                        run(str);
                        break;
                    case 7: Console.WriteLine("不是给你的红包"); break;
                    default: Console.WriteLine(obj.error_msg); break;
                }
            }
            
        }
    }
}
