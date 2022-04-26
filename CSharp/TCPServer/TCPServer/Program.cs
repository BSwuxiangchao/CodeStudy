//#define TCPSERVER
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace TCPServer
{
    class Program
    {
        
        static void Main(string[] args)
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            Console.WriteLine("Hello World!");
            TcpListener listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8081);
            listener.Start();
            TcpClient client = listener.AcceptTcpClient();
            NetworkStream networkStream = client.GetStream();
            byte[] data = new byte[1024];
            while (true)
            {
                
                int length = networkStream.Read(data,0,1024);
                string msg = Encoding.UTF8.GetString(data, 0, length);
                Console.WriteLine("client receive: " + msg);
                if (msg == "q")
                {
                    break;
                }
            }
            networkStream.Close();
            client.Close();
            listener.Stop();
            stopwatch.Stop();
            TimeSpan timeSpan = stopwatch.Elapsed;
            double milliseconds = timeSpan.TotalMilliseconds;
            Console.WriteLine("process cost total " + milliseconds + "milliseconds");
        }
    }
}
