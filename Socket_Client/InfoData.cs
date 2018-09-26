using System;
using System.Collections.Generic;
using System.Text;

namespace Socket_Client
{
    public class InfoData
    {
        #region 用于读取数据
        private byte[] data; //完整的消息 协议头+协议内容
        private byte protoTypeid;//类型
        private ushort commandId = 0;//指令号
        private int sessionId;//客户端id
        private int contentLength;//消息体长度
        public  ushort PROTO_HEAD_FLAG = 10297;
        public  int PROTO_HEAD_LEN = 7;
        private int offset = 7;//偏移量

        /// <summary>
        /// 用于接收数据
        /// </summary>
        /// <param name="data">完整的消息</param>
        /// <param name="protoTypeid">协议类型</param>
        /// <param name="commandId">指令号</param>
        /// <param name="sessionId">与客户端socketId</param>
        public InfoData(byte[] data, byte protoTypeid, ushort commandId, int contentLength, int sessionId)
        {
            this.data = data;
            this.protoTypeid = protoTypeid;
            this.commandId = commandId;
            this.sessionId = sessionId;
            this.contentLength = contentLength;
        }

        public InfoData Copy(int sessionId)
        {
            return new InfoData(data, protoTypeid, commandId, contentLength, sessionId);
        }

        /// <summary>
        /// 修改指令号
        /// </summary>
        /// <param name="commandId"></param>
        public void UpdateCommandId(ushort commandId)
        {
            int index = 3;
            foreach (var item in BitConverter.GetBytes(commandId))
            {
                data[index] = item;
                index++;
            }
        }

        private byte[] content;

        /// <summary>
        /// 获取指令号之后的内容
        /// </summary>
        /// <returns></returns>
        public byte[] Content
        {
            get
            {
                if (content != null) return content;
                content = new byte[data.Length - PROTO_HEAD_LEN];
                Array.Copy(data, PROTO_HEAD_LEN, content, 0, content.Length);
                return content;
            }

        }

        /// <summary>
        /// 获取指令Id
        /// </summary>
        public int CommandId
        {
            get { return commandId; }
        }

        /// <summary>
        /// 1 转发送给自己   2转发送给其他人  3转发给所有人  0正常 不转发
        /// </summary>
        public byte ProtoTypeid
        {
            get { return protoTypeid; }
        }

        /// <summary>
        /// 完整的消息 
        /// </summary>
        public byte[] Data
        {
            get { return data; }
        }

        /// <summary>
        /// 用于区分不同客户端连接
        /// </summary>
        public int SessionId
        {
            get { return sessionId; }
        }

        /// <summary>
        /// 获取消息体长度
        /// </summary>
        public int ContentLength
        {
            get { return contentLength; }
        }

        public short GetShort()
        {
            //if (offset + 2 > data.Length)
            //{
            //    return -1;
            //}
            short val = BitConverter.ToInt16(data, offset);
            offset += 2;
            return val;
        }


        /// <summary>
        /// 获取一个int值
        /// </summary>
        /// <returns></returns>
        public int GetInt()
        {
            //if (offset + 4 > data.Length)
            //{
            //    return -1;
            //}
            int val = BitConverter.ToInt32(data, offset);
            offset += 4;
            return val;
        }

        /// <summary>
        /// 获取一个string值
        /// </summary>
        /// <returns></returns>
        public string GetStr()
        {
            int count = GetInt();
            //if (count == -1) return null;
            //if (offset + count > data.Length) return null;
            string val = Encoding.UTF8.GetString(data, offset, count);
            offset += count;
            return val;
        }

        public double GetDouble()
        {
            //if (offset + 8 > data.Length) return 0;
            double val = BitConverter.ToDouble(data, offset);
            offset += 8;
            return val;
        }

        public float GetFloat()
        {
            //if (offset + 4 > data.Length) return 0;
            float val = BitConverter.ToSingle(data, offset);
            offset += 4;
            return val;
        }


        ///// <summary>
        ///// 获取列表
        ///// </summary>
        ///// <returns></returns>
        //public List<int> GetList()
        //{
        //    List<int> val = new List<int>();
        //    int count = getInt(); //元素个数
        //    if (count == -1) return null;
        //    for (int i = 0; i < count; i++)
        //    {
        //        val.Add(getInt());
        //    }
        //    return val;
        //}

        #endregion

        /*************用于写数据********************************************************/

        #region 写数据

        /// <summary>
        ///用于回写数据
        /// </summary>
        private List<byte> sendDataList;

        /// <summary>
        /// 用于向客户端发送数据
        /// </summary>
        public InfoData()
        {
            sendDataList = new List<byte>();
        }

        /// <summary>
        /// 将字节流转换成自己自己数组
        /// </summary>
        /// <param name="commandId">指令号</param>
        /// <returns></returns>
        public byte[] ToArray(ushort commandId, byte protoType)
        {
            sendDataList.InsertRange(0, BitConverter.GetBytes(Convert.ToUInt16(sendDataList.Count)));
            sendDataList.InsertRange(0, BitConverter.GetBytes(commandId));
            sendDataList.Insert(0, protoType);
            sendDataList.InsertRange(0, BitConverter.GetBytes(PROTO_HEAD_FLAG));
            return sendDataList.ToArray();
        }

        /// <summary>
        /// 封装
        /// </summary>
        /// <param name="data"></param>
        /// <param name="commandId"></param>
        /// <param name="protoType"></param>
        /// <returns></returns>
        public void SetFlatArray(byte[] data, ushort commandId, byte protoType, int sessionId)
        {
            sendDataList.AddRange(BitConverter.GetBytes(PROTO_HEAD_FLAG));
            sendDataList.Add(protoType);
            sendDataList.AddRange(BitConverter.GetBytes(commandId));
            sendDataList.AddRange(BitConverter.GetBytes(Convert.ToUInt16(data.Length)));
            sendDataList.AddRange(data);
            this.sessionId = sessionId;
            this.data = sendDataList.ToArray();
            this.commandId = commandId;
            this.protoTypeid = protoType;
            this.contentLength = data.Length;
        }



        public void W_Byte(byte data)
        {
            sendDataList.Add(data);
        }
        public void Add(byte data)
        {
            sendDataList.Add(data);
        }

        public void W_Byte(byte[] data)
        {
            sendDataList.AddRange(data);
        }
        public void Add(byte[] data)
        {
            sendDataList.AddRange(data);
        }

        public void W_Int(int data)
        {
            W_Byte(BitConverter.GetBytes(data));
        }
        public void Add(int data)
        {
            W_Byte(BitConverter.GetBytes(data));
        }

        public void W_Float(float data)
        {
            W_Byte(BitConverter.GetBytes(data));
        }
        public void Add(float data)
        {
            W_Byte(BitConverter.GetBytes(data));
        }

        public void W_Double(double data)
        {
            W_Byte(BitConverter.GetBytes(data));
        }
        public void Add(double data)
        {
            W_Byte(BitConverter.GetBytes(data));
        }

        public void W_Bool(bool data)
        {
            W_Byte(BitConverter.GetBytes(data));
        }
        public void Add(bool data)
        {
            W_Byte(BitConverter.GetBytes(data));
        }

        public void Add(ushort data)
        {
            W_Byte(BitConverter.GetBytes(data));
        }

        public void Add(uint data)
        {
            W_Byte(BitConverter.GetBytes(data));
        }

        public void Add(ulong data)
        {
            W_Byte(BitConverter.GetBytes(data));
        }

        public void W_String(string data)
        {
            byte[] temp = Encoding.UTF8.GetBytes(data);
            W_Byte(BitConverter.GetBytes(temp.Length));
            W_Byte(temp);
        }

        public void Add(string data)
        {
            byte[] temp = Encoding.UTF8.GetBytes(data);
            W_Byte(BitConverter.GetBytes(temp.Length));
            W_Byte(temp);
        }
        #endregion
    }
}
