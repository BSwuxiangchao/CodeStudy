using System;
using Fleck;
using System.Collections.Generic;


namespace WSServer
{
    class Program
    {
        string IP_ = "127.0.0.1";
        int Port_ = 9091;
        private static Fleck.WebSocketServer server_= null;
        private Dictionary<string, IWebSocketConnection> connetDic = new Dictionary<string, IWebSocketConnection>(); 
        public void run(string ip, int port)
        {
            server_ = new Fleck.WebSocketServer("ws://" + ip + ":" + port);
            if(server_ != null)
            {
                IP_ = ip;
                Port_ = port;
            }
            else
            {
                server_ = new Fleck.WebSocketServer("ws://" + IP_ + ":" + Port_);
            }
            server_.Start(socket =>
            {
                socket.OnOpen = () =>
                 {
                     Console.WriteLine(socket.ConnectionInfo.ClientIpAddress.ToString() + "has connected..");
                     connetDic.Add(socket.ConnectionInfo.ClientIpAddress.ToString(), socket);
                 };
                socket.OnClose = () =>
                  {
                      foreach (var ss in connetDic.Keys)
                      {
                          if (connetDic[ss].Equals(socket))
                          {
                              Console.WriteLine(ss + "has closed..");
                              connetDic.Remove(ss);
                          }
                      }
                  };
                socket.OnMessage = message =>
                  {
                      //handleMessage(socket, message);
                      Console.WriteLine("receive: " + message);
                      sendMessageToOthers(socket.ConnectionInfo.ClientIpAddress.ToString(),message);
                };

            }
            );
        }

        private void sendMessageToAll(string Message)
        {
            foreach(var k in connetDic.Keys)
            {
                connetDic[k].Send(Message);
            }
        }
        private void sendMessageToOthers(string clientName, string Message)
        {
            foreach (var k in connetDic.Keys)
            {
                if (k == clientName)
                    continue;
                connetDic[k].Send(Message);
            }
        }
        private void sendMessage(string clientName, string Message)
        {
            if(connetDic.ContainsKey(clientName))
            {
                connetDic[clientName].Send(Message);

            }
            else
            {
                Console.WriteLine("No client name " + clientName + " connected");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Program p = new Program();
            p.run(p.IP_, p.Port_);
            var input = Console.ReadLine();
            while(input !="q")
            {
                p.sendMessageToAll(input);
                input = Console.ReadLine();
            }
        }
    }
}
