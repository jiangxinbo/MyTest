using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace 多线程
{
    public class 生产消费
    {
        int cs = 0;
        public void run()
        {
            ConcurrentQueue<int> objall = new ConcurrentQueue<int>();
            BlockingCollection<int> all = new BlockingCollection<int>(objall);
            Task.Factory.StartNew(() =>
            {
                foreach (var i in all.GetConsumingEnumerable())
                {
                    if (i == cs)
                        Console.WriteLine("从集合中取出: " + i);
                }
            });
            while (true)
            {
                var param = Console.ReadLine();
                Console.Clear();

                if (int.Parse(param) > 0)
                {
                    cs = int.Parse(param);
                    for (int i = 0; i <= cs; i++)
                    {
                        all.TryAdd(i);
                    }
                }
            }
        }
    }
}
