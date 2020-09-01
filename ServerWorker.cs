using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClassDemoTCPServer
{
    class ServerWorker
    {
        public void Start()
        {
            // opret server
            // Ip egen computer , port 7 er en ekko port og er det samme som 127.0.0.1 samt egens ip addresse.
            TcpListener server = new TcpListener(IPAddress.Loopback, 7);
            server.Start();
            TcpClient socket = server.AcceptTcpClient();
            while (true)
            {
                // Venter på en klient skal have et opkald
                

                DoClient(socket);

                
            }


            socket.Close();

        }                                                                                      

        public void DoClient(TcpClient socket)
        {
            NetworkStream ns = socket.GetStream();

            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);

            // læs tekst fra klient
            string line = sr.ReadLine();
            Console.WriteLine($"her er server input: {line}");

            //calculate letters
            int AmountLetters = line.Length;

            // skriv tilbage til klient
            sw.WriteLine($"Server sender tilbage {line}, som indeholder {AmountLetters} karaktere");
            sw.Flush(); // tømmer buffer
        }
    }
}
