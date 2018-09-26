using System;

namespace 委托
{
    class Program
    {
        static void Main(string[] args)
        {
            Demo1 demo = new Demo1();
            demo.Fun2((x,b) => x.age+b == 20);
 
        }
    }
}
