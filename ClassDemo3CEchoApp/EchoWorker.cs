using System;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ClassDemo3CEchoApp
{
    internal class EchoWorker
    {
        public EchoWorker()
        {
        }

        public void Start()
        {
            TcpListener listener = new TcpListener(7);
            listener.Start();
            {
                while (true) // kan håndterer flere klienter
                {
                    TcpClient socket = listener.AcceptTcpClient();

                    Task.Run(  // håndterer flere klienter samtidigt
                        () => { DoClient(socket); }
                    );
                }

            }
        }

        private void DoClient(TcpClient socket)
        {
            using (StreamReader sr = new StreamReader(socket.GetStream()))
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            {
                String str = sr.ReadLine();
                Console.WriteLine("Server har modtaget : " + str);

                sw.WriteLine(str);
                sw.Flush();
            }

            socket?.Close();
        }
    }
}