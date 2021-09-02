using System;
using System.IO;
using System.Net.Sockets;

namespace ClassDemo3CEchoApp
{
    internal class EchoWorker
    {
        public EchoWorker()
        {
        }

        public void Start()
        {
            TcpListener listener = new TcpListener(7777);
            listener.Start();

            TcpClient socket = listener.AcceptTcpClient();

            using(StreamReader sr = new StreamReader(socket.GetStream()))
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            {
                String str = sr.ReadLine();
                Console.WriteLine("Server har modtaget : " + str);

                sw.WriteLine(str);
                sw.Flush();
            }

        }
    }
}