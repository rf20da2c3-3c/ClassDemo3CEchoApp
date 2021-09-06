using System;
using System.IO;
using System.Net.Sockets;

namespace EchoClient
{
    internal class ClientWorker
    {
        public ClientWorker()
        {
        }

        public void Start()
        {
            TcpClient socket = new TcpClient("localhost", 7);

            using (StreamReader sr = new StreamReader(socket.GetStream()))
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            {
                // read line from keyboard
                Console.Write("Write a line : ");
                String line = Console.ReadLine();

                sw.WriteLine(line);
                sw.Flush();

                String str = sr.ReadLine();
                Console.WriteLine("Server svar: " + str);

                
            }

        }
    }
}