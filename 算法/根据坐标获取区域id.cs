using System;
using System.Collections.Generic;
using System.Text;

namespace 算法
{
    public class 根据坐标获取区域id
    {
        public int updatePostion(float x, float y, float z)
        {
            int yline = Convert.ToInt32(Math.Ceiling((y - World.pointMinY) / Area.heigh));
            int xline = Convert.ToInt32(Math.Ceiling((x - World.pointMinX) / Area.width));
            int areaId = World.columnNum * ((yline == 0 ? 1 : yline) - 1) + (xline == 0 ? 1 : xline);


            Area area = World.areaDict[12];
            foreach(var item in area.AdjacentArea)
            {
                Console.WriteLine(item.Id);
            }






            return areaId;
        }
    }

    public class World
    {
        public static float pointMinX = 0;
        public static float pointMinY = 0;
        public static float width = 100;
        public static float height = 100;
        public static int columnNum;
        public static int rowNum;
        public static int maxArea;
        public static Dictionary<int, Area> areaDict = new Dictionary<int, Area>();

        static World()
        {
            columnNum = Convert.ToInt32(Math.Ceiling((width - pointMinX) / Area.width));
            rowNum = Convert.ToInt32(Math.Ceiling((height - pointMinY) / Area.heigh));
            //区域总数
            maxArea = rowNum * columnNum;

            for (int i = 1; i <= maxArea; i++)
            {//添加所有区域到内存字典中
                areaDict.Add(i, new Area(i));
            }

            foreach (var item in areaDict.Values)
            {//给当前区域添加邻居
                item.AdjacentArea = getAdjacentArea(item.Id);
            }
        }

        private static List<Area> getAdjacentArea(int id)
        {
            List<Area> list = new List<Area>();
            //相邻区块id列表
            int[] neighborIdList = null;
            if(id==1)
            {//区域在左下角
                neighborIdList = new[] { 0, 1, columnNum, columnNum+1 };
            }
            else if(id==columnNum)
            {//区域在右下角
                neighborIdList = new[] { 0, -1, columnNum-1, columnNum };
            }
            else if(id== (maxArea - columnNum + 1))
            {//区域在左上角
                neighborIdList = new[] { 0, 1, -columnNum, -(columnNum-1) };
            }
            else if(id==maxArea)
            {//区域在右上角
                neighborIdList = new[] { 0, -1, -columnNum, -(columnNum + 1) };
            }
            else if(id%columnNum==1)
            {//区域在最左侧
                neighborIdList = new[] { 0, 1, -columnNum, -(columnNum - 1),columnNum, columnNum+1 };
            }
            else if(id%columnNum==0)
            {//区域在最右侧
                neighborIdList = new[] { 0, -1, -columnNum, -(columnNum + 1), columnNum-1, columnNum };
            }
            else
            {//区域在其他位置
                neighborIdList = new int[] { -(columnNum + 1), -columnNum, -(columnNum - 1), -1,0, 1, columnNum - 1, columnNum, columnNum + 1 };
            }
            foreach (int offset in neighborIdList)
            {
                int areaid = id + offset;
                if (areaid > 0 & areaid <= maxArea)
                {
                    list.Add(areaDict[areaid]);
                }
            }
            return list;
        }
    }


    public class Area
    {
        private int id;
        public Area(int id)
        {
            this.id = id;
        }
        public const float width = 10;
        public const float heigh = 10;

        public List<Area> AdjacentArea;

        public int Id { get => id; }

        
        

    }


}
