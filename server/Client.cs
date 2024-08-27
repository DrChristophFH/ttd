using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Client
{
    class Client
    {
        public IPAddress serverAddr = IPAddress.Parse("127.0.0.1");
        public int serverPort = 55555;

        public static async void Connect(IPEndPoint localEndPoint, Socket client)
        {
            await client.ConnectAsync(localEndPoint);

        }
        static void Main(string[] args)
        {
            Client client = new Client();
            IPEndPoint localEndPoint = new IPEndPoint(client.serverAddr, client.serverPort);
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
        ProtocolType.Tcp );
        byte[] bytes = new byte[1024];
        Connect(localEndPoint,s);
   
        while (true)
        {
            Console.WriteLine("Waiting for message...");
            
            Console.ReadLine();
            int byteCount = s.Receive(bytes, 0, bytes.Length,SocketFlags.None);
            Console.WriteLine(Encoding.UTF8.GetString(bytes, 0, byteCount));

        }
        }


    }
    }
