using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCP伺服器端
{
    class Message
    {
        public byte[] data = new byte[1024];
        public int startIndex = 0; //data裡面存了多少位元組，也是下一次讀取的一個索引
        public int remainSize;

        public Message()
        {
            remainSize = data.Length - startIndex;
        }

        public void AddCount(int count)
        {
            startIndex += count;
            remainSize = data.Length - startIndex;
        }

        //由於客戶端傳送的資料比較頻繁，會出現粘包，99條資料最終可能粘成了2-3個包，
        public void ReadMessage()
        {
            while (true)
            {
                if (startIndex <= 4)
                {    //解決粘包問題
                    Console.WriteLine("不構成一條訊息");
                    return;
                }
                int count = BitConverter.ToInt32(data, 0); //得到訊息長度
                Console.WriteLine("count : " + count);
                Console.WriteLine("startIndex-4 : " + (startIndex - 4));
                if ((startIndex - 4) >= count)  //緩衝中待處理的資料個數是否大於本次傳送的訊息長度
                {
                    string s = Encoding.UTF8.GetString(data, 4, count);
                    Console.WriteLine("收到資料：" + s);
                    Array.Copy(data, count + 4, data, 0, startIndex - 4 - count);
                    startIndex -= (count + 4);
                }
                else
                {    //  解決分包問題
                    Console.WriteLine("訊息過長不做處理");
                    break;
                }

            }
        }
    }
}