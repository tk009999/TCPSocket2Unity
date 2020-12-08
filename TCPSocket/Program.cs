using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace TCP伺服器端
{
    class Program
    {
        public static IPAddress LocalIPAddress { get { return IPAddress.Parse("192.168.1.137"); } }
        public static int Port { get { return 42000; } }
        public static IPEndPoint EndPoint { get { return new IPEndPoint(LocalIPAddress, Port); } }

        static void Main(string[] args)
        {
            AsyncStart();
            Console.ReadKey();
        }
        //static byte[] dataBuffer = new byte[1024];
        //非同步Socket
        static void AsyncStart()
        {
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(EndPoint);
            serverSocket.Listen(0);
            Console.WriteLine("伺服器啟動成功！");

            //Socket clientSocket = serverSocket.Accept();
            //實現可以連線多個客戶端
            serverSocket.BeginAccept(AcceptCb, serverSocket);


        }
        static Message msg = new Message();
        static void AcceptCb(IAsyncResult ar)
        {
            try
            {
                Socket serverSocket = ar.AsyncState as Socket;
                Socket clientSocket = serverSocket.EndAccept(ar);
                //傳送資料
                string msgStr = "Hello stupid 人類...";
                byte[] data = System.Text.Encoding.UTF8.GetBytes(msgStr);
                clientSocket.Send(data);

                //接收資料  實現服務端能夠接收多條資料
                clientSocket.BeginReceive(msg.data, msg.startIndex, msg.remainSize, SocketFlags.None, ReceiveCb, clientSocket);

                serverSocket.BeginAccept(AcceptCb, serverSocket);  //迴圈呼叫
            }
            catch (Exception e)
            {
                Console.WriteLine("AcceptCb失敗：" + e.Message);
            }
        }
        static void ReceiveCb(IAsyncResult ar)
        {
            try
            {
                Socket clientSocket = ar.AsyncState as Socket;
                int count = clientSocket.EndReceive(ar);
                Console.WriteLine("Receive回撥的訊息長度：" + count);
                if (count == 0)  //用來判斷客戶端是否正常判斷，不加可能伺服器端迴圈列印或者伺服器故障
                {
                    Console.WriteLine("count<=0");
                    //clientSocket.Close();
                    clientSocket.BeginReceive(msg.data, msg.startIndex, msg.remainSize, SocketFlags.None, ReceiveCb, clientSocket);  //迴圈呼叫
                }
                msg.AddCount(count);
                string msgStr = Encoding.UTF8.GetString(msg.data, 0, count);
                Console.WriteLine("收到客戶端訊息：" + msg);
                msg.ReadMessage();
                clientSocket.BeginReceive(msg.data, msg.startIndex, msg.remainSize, SocketFlags.None, ReceiveCb, clientSocket);  //迴圈呼叫
            }
            catch (Exception e)
            {
                Console.WriteLine("ReceiveCb異常：" + e);
            }
        }

    }
}