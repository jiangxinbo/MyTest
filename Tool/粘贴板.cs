using System;
using System.Collections.Generic;
using System.Text;


namespace Tool
{
    public class 粘贴板
    {
        public static void Copy(string filePath)
        {
            //string filePath = @"A:\a.jpg";
            System.Collections.Specialized.StringCollection strcoll = new System.Collections.Specialized.StringCollection();

            strcoll.Add(filePath);
            //strcoll.Add(@"C:\Users\jxb\Desktop\asdf");

            //using System.Windows.Forms;
            //Clipboard.SetFileDropList(strcoll);
        }
    }
}
