using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Base_Console
{
    public static class ByteTest
    {
        static Queue<int> data = new Queue<int>();
        static ConcurrentQueue<int> data2 = new ConcurrentQueue<int>();
        static List<int> list = new List<int>();
        static ConcurrentQueue<int> list2 = new ConcurrentQueue<int>();
        static List<Task> tasks = new List<Task>();
        static List<Task> tasks2 = new List<Task>();
        static int count = 0;
        static ByteTest()
        {
            Stopwatch st = new Stopwatch();
            st.Start();
            for (int i=0;i<99999;i++)
            {
                data.Enqueue(i);
            }
            st.Stop();
            Console.WriteLine("1 初始化赋值耗时毫秒数:" + st.ElapsedMilliseconds);

            Stopwatch st2 = new Stopwatch();
            st2.Start();
            for (int i = 0; i < 99999; i++)
            {
                data2.Enqueue(i);
            }
            st2.Stop();
            Console.WriteLine("2 初始化赋值耗时毫秒数:" + st2.ElapsedMilliseconds);

        }
        

        public static void run()
        {
            for(int j=0;j<10;j++)
            {
                Task t1 = Task.Factory.StartNew(() => {
                    for (int i = 0; i < 10000; i++)
                    {
                        int a = data.Dequeue();
                        int b = 0;
                        if(!data2.TryDequeue(out b))
                        {
                            Console.WriteLine("list 2 获取失败....................... " + b);
                        }
                        if (list.IndexOf(a) != -1)
                        {
                            Console.WriteLine("list   重复数据....................... " + a);
                        }
                        
                        int current =Interlocked.Increment(ref count);
                        list.Add(a);
                        list2.Enqueue(b);
                    }
                });
                tasks.Add(t1);
            }
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine(count);

            foreach(var item in list2)
            {
                Console.Write("  {0}  ", item);
            }
        }

        
    }
}
