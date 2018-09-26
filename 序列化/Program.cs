using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;

namespace 序列化
{
    class Program
    {
        static void Main(string[] args)
        {
            //Abc ab = new Abc();
            //ab.x = 10;
            //ab.y = 10;
            //ab.z = "10";
            ////ab.players = new System.Collections.Generic.List<Player>();
            //MemoryStream memoryStream = new MemoryStream();
            //BinaryFormatter binaryFormatter = new BinaryFormatter();
            //binaryFormatter.Serialize(memoryStream, ab);
            //var s = memoryStream.GetBuffer();


            //byte[] ss = new byte[] { 10,0,0,0,112,115,118,136,132,2,0,0,5,0,0,0};
            //var jiegoutis = BytesToStuct<Abc>(ss);





            Stopwatch sw = new Stopwatch();
            sw.Start();
            for(int i=0;i<100000;i++)
            {
                Abc abc = new Abc();
                abc.x = 10;
                //abc.players = new System.Collections.Generic.List<Player>();
                //得到结构体的大小（使用 Marshal 返回类的非托管大小（以字节为单位）。）
                int size = Marshal.SizeOf(abc);
                //创建byte数组
                byte[] bytes = new byte[size];
                //分配结构体大小的内存空间（使用 LocalAlloc 分配内存块。）
                IntPtr structPtr = Marshal.AllocHGlobal(size);
                //将结构体拷到分配好的内存空间(将数据从托管对象封送到非托管内存块)
                Marshal.StructureToPtr(abc, structPtr, false);
                //从内存空间拷到byte数组 (将数据从托管数组复制到非托管内存指针，或从非托管内存指针复制到托管数组。)
                Marshal.Copy(structPtr, bytes, 0, size);
                //释放内存空间(释放以前使用 AllocHGlobal 从进程的非托管内存中分配的内存。)
                Marshal.FreeHGlobal(structPtr);
                //返回byte数组
                var byteslength = bytes.Length;
                var jiegouti = BytesToStuct<Abc>(bytes);
            }
            sw.Stop();
            var a=sw.Elapsed.TotalSeconds;

        }


        public static T BytesToStuct<T>(byte[] bytes)
        {
            //得到结构体的大小
            int size = Marshal.SizeOf<T>();
            //byte数组长度小于结构体的大小
            if (size > bytes.Length)
            {
                //返回空
                return default(T);
            }
            //分配结构体大小的内存空间
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            //将byte数组拷到分配好的内存空间
            Marshal.Copy(bytes, 0, structPtr, size);
            //将内存空间转换为目标结构体
            T obj = Marshal.PtrToStructure<T>(structPtr);
            //释放内存空间
            Marshal.FreeHGlobal(structPtr);
            //返回结构体
            return obj;
        }
    }
}
