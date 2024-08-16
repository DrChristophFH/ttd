using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class TcpClient : IDisposable
{
    static void Connect(String server, String message)
    {
        try
        {
            Int32 port = 44444;
            using TcpClient client = new();
            
            Byte[] data = System.text.Encoding.ASCII.GetBytes(message);
            NetworkStream stream = client.GetStream();

            stream.Write(data, 0, data.Length);

            Console.WriteLine("Sent: {0}", message);

        }
        catch(ArgumentNullException e)
        {
            Console.WriteLine("Argument Null Execption: {0}: ", e);
        }
    }
}