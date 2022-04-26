using System;
using Fleck;

namespace WSClient
{
    
    class Program
    {
        static void Main(string[] args)
        {
            string ServerAddr = "WS://127.0.0.1:9091";
            Fleck.WebSocketServer server_ = new Fleck.WebSocketServer(ServerAddr);
            Fleck.WebSocketConnection webSocketConnection = null;
            //webSocketConnection = new Fleck.WebSocketConnection(server_);
            Console.WriteLine("Hello World!");

        }
    }
}
