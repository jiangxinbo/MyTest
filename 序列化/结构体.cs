using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace 序列化
{
    [StructLayout(LayoutKind.Sequential,CharSet = CharSet.Ansi,Pack =1), Serializable]
    public class Abc
    {
        public int x ;
        public string name = "abcdeflajgheroigjlfjblsdhflajgl;jfl;jf;lajf";
        //public Player b = new Player();
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1), Serializable]
    public class Player
    {
        public string name="abcdeflajgheroigjlfjblsdhflajgl;jfl;jf;lajf";
        public int age=5;
    }




}
