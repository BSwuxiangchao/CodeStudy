using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
#if TCPCLIENT
            TcpClient client = new TcpClient("127.0.0.1", 8081);
            NetworkStream networkStream = client.GetStream();
            byte[] data = new byte[1024];

            while (true)
            {
                string msg = Console.ReadLine();
                data = Encoding.UTF8.GetBytes(msg);
                networkStream.Write(data, 0, data.Length);
                if (msg == "q")
                {
                    break;
                }
            }

            networkStream.Close();
            client.Close();
#endif
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8081);
            serverSocket.Connect(ipPoint);
            while(true)
            {
                if (serverSocket.Connected)
                {
                    var input = Console.ReadLine();

                    byte[] data = new byte[1024];
                    data = Encoding.UTF8.GetBytes(input);
                    int length = serverSocket.Send(data);
                    if (input == "q")
                        break;
                }
                else
                {
                    serverSocket.Connect(ipPoint);
                    Console.WriteLine("dont connect");
                }
            }
            serverSocket.Close();

        }
    }
}
