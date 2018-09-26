using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace 多线程
{
    public class Semaphore_test
    {
        private static Semaphore _pool;

        public static void Main1()
        {
            _pool = new Semaphore(0, 1);
            for (int i = 1; i <= 50; i++)
            {
                
                Thread t = new Thread(new ParameterizedThreadStart(Worker));
                t.Start(i);
                _pool.WaitOne();
            }
            _pool.WaitOne();
            Console.WriteLine("主线程结束");
        }

        private static void Worker(object num)
        {
            var sleep = 1;//new Random().Next(1, 3);
            Console.WriteLine("线程 {0} 进入信号量{1}.", num, sleep);
            
            Thread.Sleep(sleep*1000);
            _pool.Release();
            //Thread.Sleep(1000 + padding);
            //Console.WriteLine("线程 {0} 释放信号量.", num);
            //Console.WriteLine("线程 {0} 以往信号量计数: {1}",num, _pool.Release());
        }
    }
}
