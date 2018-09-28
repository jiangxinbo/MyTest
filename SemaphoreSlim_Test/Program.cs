using System;
using System.Threading;
using System.Threading.Tasks;

namespace SemaphoreSlim_Test
{
    class Program
    {
        /// <summary>
        /// 同时可运行的任务
        /// </summary>
        public static SemaphoreSlim TaskRun = new SemaphoreSlim(100, 100);

        /// <summary>
        /// 用于避免频繁访问被封ip
        /// </summary>
        public static SemaphoreSlim WebTimeSpan = new SemaphoreSlim(1, 1);


        static void Main(string[] args)
        {
            for(int i=0;i<10000;i++)
            {
                TaskRun.Wait();
                Task.Factory.StartNew((t)=> {
                    try
                    {
                        Console.WriteLine(t);
                        getHtml((int)t);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        TaskRun.Release();
                    }
                },i);
                
            }
            Console.Read();
            Console.WriteLine("Hello World!");
        }

        static void getHtml(int t)
        {
            getMain(t);
        }

        static void getMain(int t)
        {
            WebTimeSpan.Wait();
            Console.WriteLine(DateTime.Now + "" + t);
            Thread.Sleep(100);
            WebTimeSpan.Release();
        }
    }
}
