using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace TCP客戶端
{
    class Program
    {
        public static IPAddress LocalIPAddress { get { return IPAddress.Parse("192.168.1.137"); } }
        public static int Port { get { return 42000; } }
        public static IPEndPoint EndPoint { get { return new IPEndPoint(LocalIPAddress, Port); } }

        static void Main(string[] args)
        {
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(EndPoint);
            //收到訊息
            byte[] data = new byte[1024];
            int count = clientSocket.Receive(data);
            string receiveStr = System.Text.Encoding.UTF8.GetString(data, 0, count);
            Console.WriteLine("收到伺服器訊息：" + receiveStr);
            //傳送訊息
            //while (true)
            //{
            //    //string msg = Console.ReadLine();
            //    //if (msg == "c") {
            //    //    clientSocket.Close();
            //    //    return;
            //    //}
            //}
            string s = @"這是一條文字訊息發生看了感覺as弗蘭克見鬼十法的開獎號噶水電費就考了個和介面辣雞啊撒發聖誕節快樂發貨
            撒大計科了訪華sad接口裡發哈聖誕節快樂這是一條文字訊息發生看了感覺as弗蘭克見鬼十法的開獎號噶水電費就考了個和介面
            辣雞啊撒發聖誕節快樂發貨這是一條文字訊息發生看了感覺as弗蘭克見鬼十法的開獎號噶水電費就考了個和介面辣雞啊撒發聖誕
            節快樂發貨這是一條文字訊息發生看了感覺as弗蘭克見鬼十法的開獎號噶水電費就考了個和介面辣雞啊撒發聖誕節快樂發貨
            撒大計科了訪華sad接口裡發哈聖誕節快樂這是一條文字訊息發生看了感覺as弗蘭克見鬼十法的開獎號噶水電費就考了個和介面
            辣雞啊撒發聖誕節快樂發貨這是一條文字訊息發生看了感覺as弗蘭克見鬼十法的開獎號噶水電費就考了個和介面辣雞啊撒發聖誕
            節快樂發貨這是一條文字訊息發生看了感覺as弗蘭克見鬼十法的開獎號噶水電費就考了個和介面辣雞啊撒發聖誕節快樂發貨
            撒大計科了訪華sad接口裡發哈聖誕節快樂這是一條文字訊息發生看了感覺as弗蘭克見鬼十法的開獎號噶水電費就考了個和介面
            辣雞啊撒發聖誕節快樂發貨這是一條文字訊息發生看了感覺as弗蘭克見鬼十法的開獎號噶水電費就考了個和介面辣雞啊撒發聖誕
            節快樂發貨這是一條文字訊息發生看了感覺as弗蘭克見鬼十法的開獎號噶水電費就考了個和介面辣雞啊撒發聖誕節快樂發貨
            撒大計科了訪華sad接口裡發哈聖誕節快樂這是一條文字訊息發生看了感覺as弗蘭克見鬼十法的開獎號噶水電費就考了個和介面
            辣雞啊撒發聖誕節快樂發貨這是一條文字訊息發生看了感覺as弗蘭克見鬼十法的開獎號噶水電費就考了個和介面辣雞啊撒發聖誕
            節快樂發貨這是一條文字訊息發生看了感覺as弗蘭克見鬼十法的開獎號噶水電費就考了個和介面辣雞啊撒發聖誕節快樂發貨
            撒大計科了訪華sad接口裡發哈聖誕節快樂這是一條文字訊息發生看了感覺as弗蘭克見鬼十法的開獎號噶水電費就考了個和介面
            辣雞啊撒發聖誕節快樂發貨這是一條文字訊息發生看了感覺as弗蘭克見鬼十法的開獎號噶水電費就考了個和介面辣雞啊撒發聖誕
            節快樂發貨這是一條文字訊息發生看了感覺as弗蘭克見鬼十法的開獎號噶水電費就考了個和介面辣雞啊撒發聖誕節快樂發貨
            撒大計科了訪華sad接口裡發哈聖誕節快樂這是一條文字訊息發生看了感覺as弗蘭克見鬼十法的開獎號噶水電費就考了個和介面
            辣雞啊撒發聖誕節快樂發貨這是一條文字訊息發生看了感覺as弗蘭克見鬼十法的開獎號噶水電費就考了個和介面辣雞啊撒發聖誕
            節快樂發貨這是一條文字訊息發生看了感覺as弗蘭克見鬼十法的開獎號噶水電費就考了個和介面辣雞啊撒發聖誕節快樂發貨
            撒大計科了訪華sad接口裡發哈聖誕節快樂這是一條文字訊息發生看了感覺as弗蘭克見鬼十法的開獎號噶水電費就考了個和介面
            辣雞啊撒發聖誕節快樂發貨這是一條文字訊息發生看了感覺as弗蘭克見鬼十法的開獎號噶水電費就考了個和介面辣雞啊撒發聖誕
            節快樂發貨";

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "for")
                {
                    for (int i = 1; i < 100; i++)
                    {

                        clientSocket.Send(Message.GetBytes(i.ToString() + "長度"));
                    }
                }
                else
                {
                    clientSocket.Send(Message.GetBytes("測試測試測試測試測試測試測試測試測試測試"));
                }
            }




            Console.ReadKey();
            clientSocket.Close();
        }
    }
}