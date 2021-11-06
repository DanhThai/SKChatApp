using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessServer
{
    class Server
    {
        private const int PORT = 2001;
        private List<Socket> ListClient = null;
        private List<string> list = null;
        TcpListener server;
        public void startServer()
        {
            ListClient = new List<Socket>();
            list = new List<string>();
            IPAddress IP = IPAddress.Parse("127.0.0.1");
            server = new TcpListener(IP, PORT);
            server.Start();
            Console.WriteLine("Server starting : " + server.LocalEndpoint);
            Console.WriteLine("watting connect  ...");
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
            list.Add(ipClient);
            Console.WriteLine(ipClient + " connect server");
            XuLyMessage(sk);

            sk.Close();
            ListClient.Remove(sk);
            list.Remove(ipClient);
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
                        else if (msg.Contains("#msg"))
                        {
                            string ipsend = sk.RemoteEndPoint.ToString();
                            processSendMsg(msg, ipsend);
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
            {
                //writer.WriteLine("true");
                string s = Encoding.ASCII.GetString(SerializeData());
                Console.WriteLine(s);
                writer.WriteLine(s);
                //stream.Write(SerializeData());
            }
            else
                writer.WriteLine("false");

            //else
            //writer.WriteLine("false");
        }

        public byte[] SerializeData()
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf1 = new BinaryFormatter();
            bf1.Serialize(ms, (object)list);
            return ms.ToArray();
        }
        public void processSendMsg(string msg, string ipsend)
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
                        writer.WriteLine(ipsend + " #send: " + str[1]);
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
