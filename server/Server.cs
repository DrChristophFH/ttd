using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;


namespace Server
{
    class Server
    {
        public IPAddress ipAddr = IPAddress.Parse("127.0.0.1");
        public int port = 55555;
        
        
    static void Main(string[] args)
    {   
        Server serverHost = new Server();
        IPEndPoint localEndPoint = new IPEndPoint(serverHost.ipAddr, serverHost.port);
       
        //Console.WriteLine(serverHost.ipAddr);
        //Console.WriteLine(serverHost.ipAddr.GetType());
        //Console.WriteLine(localEndPoint);
        //Console.WriteLine(localEndPoint.GetType());
        Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
        ProtocolType.Tcp );
        //Console.WriteLine(s);
        //Console.WriteLine(s.GetType());
        s.Bind(localEndPoint);
        s.Listen(5);

        while(true)
        {
            Console.WriteLine("Waiting for incoming connection...");
            Console.ReadLine();
        }
    }
   
    }
}
