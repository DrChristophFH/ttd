using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;



namespace Server
{
    class Server
    {
        static Dictionary<int, Socket> activeConnections = new Dictionary<int, Socket>();
        public static int connectionID = 0;
        int addConnection(Socket s,Dictionary<int, Socket> activeConnections, int connectionID)
        {
            activeConnections.Add(connectionID,s);
            connectionID++;
            return connectionID;
        }
        public IPAddress ipAddr = IPAddress.Parse("127.0.0.1");
        public int port = 55555;
        public async Task AcceptAsyncConnection(Socket s)
        {
            Socket handler = await s.AcceptAsync();
            Console.WriteLine("Connection accepted!");
           
            connectionID = addConnection(handler,activeConnections,connectionID);

        }
        
    static void Main(string[] args)
    {   
        Server serverHost = new Server();
        IPEndPoint localEndPoint = new IPEndPoint(serverHost.ipAddr, serverHost.port);
       

        Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
        ProtocolType.Tcp );

        s.Bind(localEndPoint);
        s.Listen(5);
        byte[] buffer = new byte[1024];
        int offset =0;

        

        while(true)
        {   

            Console.WriteLine("Waiting for incoming connection...");
            var handler = serverHost.AcceptAsyncConnection(s);
            Console.ReadLine();
            if (activeConnections.Count != 0)
            {
                Console.WriteLine("Type 'send' or 's' to send a message to a client.");
                string input = Console.ReadLine();
                
                if (input == "send")
                {
                    Console.WriteLine("Select a client to send your message to.");
                    string clientId = Console.ReadLine();
                    Console.WriteLine("Type the message you would like to send.");
                    string msg = Console.ReadLine();
                    Console.WriteLine("The message "+msg+" was sent to client: " + clientId);
                    byte[] byteMsg = Encoding.UTF8.GetBytes(msg);
                    int byteCount = activeConnections[Int32.Parse(clientId)].Send(byteMsg, 0, byteMsg.Length,SocketFlags.None);
                    if (byteCount > 0 )
                        Console.WriteLine(Encoding.UTF8.GetString(buffer, 0, byteCount));
                }
            }


            
        }
    }
   
    }
}
