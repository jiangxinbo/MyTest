using System;
using System.Diagnostics;

namespace Base_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch st = new Stopwatch();
            st.Start();
            ByteTest.run();
            st.Stop();
            Console.WriteLine("-----------------");
            //Console.WriteLine(st.ElapsedMilliseconds);
            Console.Read();
        }
    }
}
