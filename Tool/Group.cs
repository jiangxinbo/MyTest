using System;
using System.Collections.Generic;
using System.Text;

namespace Tool
{
    public class Group
    {
        public static void run()
        {
            //线程总数
            int count = 13;
            //处理页数
            int start_page = 90;
            int end_page = 101;
            int totalCount = end_page-start_page;
            //每个线程处理的数据量
            //int pagecount = Convert.ToInt32(Math.Ceiling(totalCount / (double)count));
            int star= start_page;
            for (int i = 1; i <= count; i++)
            {
                int end = start_page+totalCount * i/count;
                Console.WriteLine(" 开始{0}   结束{1}", star, end);
                star = end + 1;
            }
        }
    }
}
