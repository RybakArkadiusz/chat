// See https://aka.ms/new-console-template for more information

using System.Net;
using System.Net.Sockets;
using System.Text;

namespace client
{
    class clientProgram
    {
        private static Socket _clientSocket =
            new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        
        static void Main(string[] args)
        {
            Console.Title = "Client";
            LoopConnect();
            SendLoop();
            Console.ReadLine();
        }

        private static void SendLoop()
        {
            Menu menu = new Menu();
            while (true)
            {
                string request = menu.run();
                byte[] buffer = Encoding.ASCII.GetBytes(request);
                _clientSocket.Send(buffer);

                byte[] receivedBuffer = new byte[1024];
                int rec = _clientSocket.Receive(receivedBuffer);
                byte[] data = new byte[rec];
                Array.Copy(receivedBuffer,data,rec);
                Console.WriteLine("Received: "+Encoding.ASCII.GetString(receivedBuffer));
            }
        }

        public static void LoopConnect()
        {
            int attempts = 0;
            while (!_clientSocket.Connected)
            {
                try
                {
                    attempts++;
                    _clientSocket.Connect(IPAddress.Loopback, 100);
                }
                catch (SocketException)
                {
                    Console.Clear();
                    Console.WriteLine("Attempts: "+attempts.ToString());
                }
            }
            Console.Clear();
            Console.WriteLine("Connected");

        }
        
    }
}