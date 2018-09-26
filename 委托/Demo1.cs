using System;
using System.Collections.Generic;
using System.Text;

namespace 委托
{
    public delegate bool Weituo2(Player obj,int b);

    public class Demo1
    {
        public void Fun2(Weituo2 obj)
        {
            Player p = new Player();
            p.name = "小命";
            p.age = 19;
            if(obj(p,1))
            {
                Console.WriteLine(p.name);
            }
        }
    }
}
