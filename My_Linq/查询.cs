using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My_Linq
{
    public class 查询
    {
       
        public 查询()
        {
            float x = 5;
            float y = 5;
            int yline = Convert.ToInt32(Math.Ceiling((y+World.pointY) / 10));
            int xline = Convert.ToInt32(Math.Ceiling((x+World.pointX) / 10));
            var a = 6 * ((yline == 0 ? 1 : yline) - 1);
            var b = xline == 0 ? 1 : xline;
            int areaId = 6 * ((yline == 0 ? 1 : yline) - 1) + (xline == 0 ? 1 : xline);
            Console.WriteLine(areaId);
            Console.Read();
        }
    }

    public class World
    {
        public static float pointX=1;
        public static float pointY=5;
    }
}
