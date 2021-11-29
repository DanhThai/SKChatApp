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
        TcpListener server;
        public void startServer()
        {
            ListClient = new List<Socket>();
            IPAddress IP = IPAddress.Parse("192.168.1.201");
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
            while (true)
            {
                try
                {
                    if (!sk.Connected)
                    {
                        break;
                    }

                    else
                    {
                        string msg = reader.ReadLine();
                        string ipsend = sk.RemoteEndPoint.ToString();
                        Console.WriteLine(msg);
                        if (msg != null && msg.Contains("#Disconnect"))
                            break;

                        else if (msg != null && msg.Contains("#Login"))
                            processLogin(msg, ipsend, stream);

                        else if (msg != null && msg.Contains("#msg"))
                            processSendMsg(msg, sk);

                        else if (msg != null && msg.Contains("#Search"))
                            processSearch(msg, stream);
                        else if (msg != null && msg.Contains("#ChangePass"))
                            Console.WriteLine(msg);
                        else if (msg != null && msg.Contains("#AddFriend"))
                            processAddFriend(msg, sk);
                        else if (msg != null && msg.Contains("#AcceptFriend"))
                            processAcceptFriend(msg, sk);

                        else if (msg != null && msg.Contains("#SignUp"))
                            Console.WriteLine("OK");
                        else
                            continue;
                    }
                }
                catch (Exception e)
                {
                    stream.Close();
                    //ListClient.Remove(sk);
                    //sk.Close();
                    Console.WriteLine(e.Message);
                }
            }
            stream.Close();
        }
        public void sendMsg(string msg, string ip, int id)
        {

            foreach (var i in ListClient)
            {
                try
                {
                    if (ip.Contains(i.RemoteEndPoint.ToString()))
                    {
                        Console.WriteLine("msg send to:"+ i.RemoteEndPoint.ToString()+" " + msg);
                        NetworkStream stream = new NetworkStream(i);
                        var writer = new StreamWriter(stream);
                        writer.AutoFlush = true;
                        writer.WriteLine(id + " #send: " + msg);
                        stream.Close();
                        break;
                    }
                }
                catch (Exception ex)
                {                 
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void sendFriend(List<byte[]> data, NetworkStream stream)
        {
            if (data.Count > 0)
            {
                foreach (byte[] i in data)
                {
                    string msg = Encoding.ASCII.GetString(i);
                    Console.WriteLine(msg);
                    stream.Write(i, 0, i.Length);
                    //Thread.Sleep(3);
                }
                //Thread.Sleep(1);
                string s = "#done";
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
        // send friend list, info to client 
        public void processLogin(string msg, string ip, NetworkStream stream)
        {
            //msg="#Login: user pass"
            string[] str = msg.Split(' ');

            List<byte[]> data = Client.instance.checkLogin(str[1], str[2], ip);
            sendFriend(data, stream);

            //Thread.Sleep(3);
            byte[] info = Client.instance.getInformation(ip);

            string msgs = Encoding.ASCII.GetString(info);
            Console.WriteLine(msgs);

            stream.Write(info, 0, info.Length);
            //Thread.Sleep(1);
        }

        // send massage to client 
        public void processSendMsg(string msg, Socket sender)
        {
            string[] str = msg.Split(new string[] { " #msg: " }, StringSplitOptions.None);
            //mess is message
            string mess = str[1];
            string[] check = str[0].Split(new string[] { " " }, StringSplitOptions.None);
            //id sender
            int id = Client.instance.getIDbyIP(sender.RemoteEndPoint.ToString());
            //Console.WriteLine(str[1]);
            // msg= "#ID: id #msg: msg", check[1]=id
            if (msg.Contains("#ID"))
            {
                //ip reciever
                string ip = Client.instance.checkIPbyID(Convert.ToInt32(check[1]));
                Console.WriteLine("ip send:" + sender.RemoteEndPoint.ToString()+"ip receiev:"+ip);
                //update ip for client
                if (ip != null)
                {
                    var stream = new NetworkStream(sender);
                    var writer = new StreamWriter(stream);
                    writer.AutoFlush = true;
                    //msg = "#UpdateIP: id ipnew"
                    writer.WriteLine("#UpdateIP: " + check[1] + " " + ip);
                    sendMsg(mess, ip, id);
                    
                }
            }
            // msg= "#IP: ip #msg: msg",check[1]=ip
            else
            {
                Console.WriteLine("send to ip: "+check[1]);
                sendMsg(mess, check[1], id);
            }
        }

        public void processSearch(string msg, NetworkStream stream)
        {
            //msg= #Search: name
            var writer = new StreamWriter(stream);
            writer.AutoFlush = true;
            writer.WriteLine("#Search");
            string[] str = msg.Split(new string[] { "#Search: " }, StringSplitOptions.None);
            List<byte[]> data = Client.instance.searchFriend(str[1]);
            Console.WriteLine(str[1]);
            sendFriend(data, stream);
        }
        public void processAddFriend(string msg, Socket sender)
        {
            // msg= "#AddFriend: id ip"
            string[] str = msg.Split(' ');
            //ip of online receiver 
            string ip = Client.instance.checkIPbyID((Convert.ToInt32(str[1])));
            // data of sended client 
            byte[] datasender = Client.instance.getClientByIP(sender.RemoteEndPoint.ToString());
            if (ip != null)
            {
                foreach (Socket i in ListClient)
                {
                    if (ip.Equals(i.RemoteEndPoint.ToString()))
                    {
                        var stream = new NetworkStream(i);
                        var writer = new StreamWriter(stream);
                        writer.AutoFlush = true;
                        // msg= "#MakeFriend: id ip"
                        writer.WriteLine("#MakeFriend:");
                        Thread.Sleep(2);
                        stream.Write(datasender, 0, datasender.Length);
                        stream.Close();
                        break;
                    }
                }
            }
        }
        public void processAcceptFriend(string msg, Socket sender)
        {
            // masg="#AcceptFriend: ip"
            string[] str = msg.Split(' ');

            //ip of online receiver 
            //string ip = Client.instance.checkIPbyID((Convert.ToInt32(str[1])));
            // data of sended client
            byte[] datasender = Client.instance.getClientByIP(sender.RemoteEndPoint.ToString());

            foreach (Socket i in ListClient)
            {
                if (str[1].Equals(i.RemoteEndPoint.ToString()))
                {
                    var stream = new NetworkStream(i);
                    var writer = new StreamWriter(stream);
                    writer.AutoFlush = true;
                    // msg= "#AcceptFriend:"
                    writer.WriteLine("#AcceptFriend:");
                    Thread.Sleep(2);
                    stream.Write(datasender, 0, datasender.Length);
                    stream.Close();
                    break;
                }
            }

        }
    }
}
