using FlatBuffers;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Socket_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = 1988;
            string host = "127.0.0.1"; //"101.132.100.24";//服务器端ip地址  "127.0.0.1"; //

            IPAddress ip = IPAddress.Parse(host);
            IPEndPoint ipe = new IPEndPoint(ip, port);

            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(ipe);

            var builder = new FlatBufferBuilder(1);
            var weapon1 = builder.CreateString("1");
            var weapon2 = builder.CreateString("2");
            var weapon3 = builder.CreateString("3");
            var pos=LoginReq.CreateLoginReq(builder, weapon1, weapon2, weapon3);
            builder.Finish(pos.Value);
            byte[] resp_data  = new byte[builder.Offset];
            Buffer.BlockCopy(builder.DataBuffer.Data, builder.DataBuffer.Position, resp_data, 0, resp_data.Length);

            //send message
            InfoData info = new InfoData();
            info.SetFlatArray(resp_data, 1, 0, 1);
            clientSocket.Send(info.Data);

            //receive message
            string recStr = "";
            byte[] recBytes = new byte[4096];
            int bytes = clientSocket.Receive(recBytes, recBytes.Length, 0);
            byte[] list = new byte[bytes];
            Buffer.BlockCopy(recBytes, 0, list, 0, bytes);
            ushort length = BitConverter.ToUInt16(list, 5);
            ushort flag = BitConverter.ToUInt16(list, 0);
            byte protoTypeid = list[2];
            ushort commandId = BitConverter.ToUInt16(list, 3);

            byte[] jieguo = new byte[bytes-7];
            Buffer.BlockCopy(list, 7, jieguo, 0, jieguo.Length);
            var bf = new ByteBuffer(jieguo);
            LoginResp reqdata = LoginResp.GetRootAsLoginResp(bf);
            var a = reqdata.Guid;
            var b = reqdata.X;
            var c = reqdata.Y;
            var d = reqdata.Z;
            recStr += Encoding.Default.GetString(recBytes, 0, bytes);
            Console.WriteLine(recStr);

            clientSocket.Close();
        }
    }
}
