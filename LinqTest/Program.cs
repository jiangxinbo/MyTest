using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] dict = { "1我是神", "3a我在那里", "6abc123","2wer","0高文文*23人" };

            var list = from n in dict
                       where n.Length > 0
                       orderby n ascending
                       group n by n.Contains("*");
 






            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

        }
    }
}
