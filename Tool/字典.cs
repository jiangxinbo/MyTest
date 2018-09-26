using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tool
{
    public class 字典
    {
        public void 获取差集()
        {
            Dictionary<int, int> a = new Dictionary<int, int>();
            a.Add(0, 2);
            a.Add(1, 3);
            a.Add(2, 3);
            a.Add(3, 3);
            a.Add(4, 3);
            a.Add(5, 3);
            Dictionary<int, int> b = new Dictionary<int, int>();
            b.Add(2, 1);
            var tt = a.Keys.Except(b.Keys);
            Console.WriteLine("('" + string.Join<int>("','", tt) + "')");
            foreach (var item in b.Keys.Except(a.Keys))
            {
                Console.WriteLine(item);
            }
        }
    }
}
