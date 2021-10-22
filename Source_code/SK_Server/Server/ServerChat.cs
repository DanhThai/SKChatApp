using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class ServerChat
    {
        private const int PORT = 2001;
        private List<Socket> ListClient = null;
        TcpListener server;      
        public void ConnectSV()
        {
            ListClient = new List<Socket>();
            IPAddress IP = IPAddress.Parse("127.0.0.1");
            server = new TcpListener(IP, PORT);
            server.Start();
            Console.WriteLine("Server bắt đầu kết nối tới Server là:  " + server.LocalEndpoint);
            Console.WriteLine("Đang chờ kết nối ...");
            while (true)
            {
                Socket sk = server.AcceptSocket();
                Thread thread = new Thread(() => HandleClient(sk));
                thread.Start();
                thread.IsBackground = true;
            }
        }
        public void HandleClient(Socket sk)
        {
            string ipClient = sk.RemoteEndPoint.ToString();
            ListClient.Add(sk);
            Console.WriteLine(ipClient + " connect server");
            XuLyMessage(sk);

            sk.Close();
            ListClient.Remove(sk);
            Console.WriteLine(ipClient + " disconnect server");
        }
        public void XuLyMessage(Socket sk)
        {
            NetworkStream stream = new NetworkStream(sk);
            var reader = new StreamReader(stream);
            var writer = new StreamWriter(stream);
            writer.AutoFlush = true;
            try
            {
                while (true)
                {
                    if (!sk.Connected)
                        break;

                    else
                    {
                        string msg = reader.ReadLine();
                        Console.WriteLine(msg);
                        if (msg.Contains("#Login"))
                            processLogin(msg, stream);
                        else if(msg.Contains("#msg"))
                        {                                                    
                            processSendMsg(msg);
                        }
                        else
                            continue;
                    }
                }
                stream.Close();
            }
            catch (Exception e)
            {
                stream.Close();
                ListClient.Remove(sk);
                sk.Close();
                Console.WriteLine(e.Message);
            }
        }
        public void processLogin(string msg, NetworkStream stream)
        {
            string[] str = msg.Split(' ');
            var writer = new StreamWriter(stream);
            writer.AutoFlush = true;
            if (str[1] == "user" && str[2] == "pass")
                writer.WriteLine("true");
            else
                writer.WriteLine("false");
        }
        public void processSendMsg(string msg)
        {
            string[] str = msg.Split(new string[] { " #msg: " }, StringSplitOptions.None);
            string ip = str[0];
            NetworkStream stream = null;
            foreach (var i in ListClient)
            {
                try
                {
                    if (ip.Contains(i.RemoteEndPoint.ToString()))
                    {
                        stream = new NetworkStream(i);
                        var writer = new StreamWriter(stream);
                        writer.AutoFlush = true;
                        writer.WriteLine(i.RemoteEndPoint.ToString() + " send: " + str[1]);
                        stream.Close();
                    }
                }
                catch (Exception ex)
                {
                    stream.Close();
                    Console.WriteLine(ex.Message);
                }

            }
        }

    }
}
