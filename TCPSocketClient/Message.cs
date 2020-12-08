using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCP客戶端
{
    class Message
    {
        public static byte[] GetBytes(string msg)
        {

            byte[] data = Encoding.UTF8.GetBytes(msg);
            int len = data.Length;
            byte[] lenBytes = BitConverter.GetBytes(len);
            byte[] sendBuffer = lenBytes.Concat(data).ToArray();
            return sendBuffer;
        }
    }
}