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
                        string ipsend = sk.RemoteEndPoint.ToString();
                        Console.WriteLine(msg);
                        if (msg.Contains("#Login"))
                            processLogin(msg, ipsend, stream);
                        else if (msg.Contains("#msg"))
                        {                         
                            processSendMsg(msg, sk);
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
        public void processLogin(string msg,string ip, NetworkStream stream)
        {
            string[] str = msg.Split(' ');
            var writer = new StreamWriter(stream);
            writer.AutoFlush = true;
            List<byte[]> data = CheckAccount.instance.checkLogin(str[1], str[2],ip);

            if(data!=null)
            {
                foreach(byte[] i in data)
                {
                    string ss = Encoding.ASCII.GetString(i);
                    Console.WriteLine(ss);
                    //writer.WriteLine(i);
                    stream.Write(i,0,i.Length);
                }
                Thread.Sleep(30);
                string s= "#done";
                byte[] bytes = Encoding.ASCII.GetBytes(s);
                stream.Write(bytes, 0, bytes.Length);
            }   
            else
            {
                string s = "#false";
                byte[] bytes = Encoding.ASCII.GetBytes(s);
                stream.Write(bytes, 0, bytes.Length);
            }    
        }

        public byte[] SerializeData()
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf1 = new BinaryFormatter();
            bf1.Serialize(ms, (object)list);
            return ms.ToArray();
        }
        public void processSendMsg(string msg, Socket sender)
        {
            
            
            string[] str = msg.Split(new string[] {" #msg: "}, StringSplitOptions.None);
            //mess is message
            string mess = str[1];
            string []check = str[0].Split(new string[] { " " }, StringSplitOptions.None);
            int id = CheckAccount.instance.getIDbyIP(sender.RemoteEndPoint.ToString());
            Console.WriteLine(str[1]+check[1]);
            // msg= "#ID: id #msg: msg"
            if (msg.Contains("#ID"))
            {
                //ip reciever
                string ip = CheckAccount.instance.checkIPbyID(Convert.ToInt32(check[1]));
                //update ip for client
                if(ip!=null)
                {
                    var stream = new NetworkStream(sender);
                    var writer = new StreamWriter(stream);
                    writer.AutoFlush = true;
                    writer.WriteLine(check[1] + " #UpdateIP: " + ip);
                    
                    foreach (Socket i in ListClient)
                    {
                        if (ip.Equals(i.RemoteEndPoint.ToString()))
                        {
                            sendMsg(mess, ip, id);
                        }
                    }
                }                                    
            }
            // msg= "#IP: ip #msg: msg"
            else
            {

                sendMsg(mess, check[1], id);
            }    
        }
        public void sendMsg(string msg,string ip,int id)
        {
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
                        writer.WriteLine(id + " #send: " +msg);
                        stream.Close();
                        break;
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
