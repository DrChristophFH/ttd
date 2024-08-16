using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

class HostServer {
    public static void Main()
    {
        TcpListener server = null;
        try
        {
            Int32 port = 44444;
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");

            server = new TcpListener(localAddr, port);
            server.Start();

            Byte[] bytes = new Byte[256];
            String data = null;

            while(true)
            {
                Console.Write("Waiting for a connection...");
                
                using (TcpClient client = server.AcceptTcpClient())
                {
                    data = null;
                
                    NetworkStream stream = client.GetStream();
                    Console.WriteLine("Connected!");

                    data = null;
                
                

                    int i;

                }
                 while((i = stream.Read(bytes, 0, bytes.Length))!=0)
                    {
                    // Translate data bytes to a ASCII string.
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    Console.WriteLine("Received: {0}", data);

                    // Process the data sent by the client.
                    data = data.ToUpper();

                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                    // Send back a response.
                    stream.Write(msg, 0, msg.Length);
                    Console.WriteLine("Sent: {0}", data);
                    }
                
            }
        }
        catch 
        {
            Console.WriteLine("Yeap.");
        }
    }
        
}