using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessServer
{
    class ServerCall
    {
        private const int PORT1 = 2002;
        private const int PORT2 = 2003;
        private List<Socket> ListClient = null;
        private List<string> ListID = null;
        TcpListener server1;
        TcpListener server2;
        public static List<string> ListIPGroup;
        public void startServer()
        {
            ListClient = new List<Socket>();
            ListID = new List<string>();
            ListIPGroup = new List<string>();
            IPAddress IP = IPAddress.Parse("192.168.1.201");
            server1 = new TcpListener(IP, PORT1);
            server1.Start();
            Console.WriteLine("Server call starting : " + server1.LocalEndpoint);
            while (true)
            {
                Socket sk = server1.AcceptSocket();
                
                Thread thread = new Thread(() => HandleClient(sk));
                thread.Start();
                thread.IsBackground = true;
            }
        }
        public void HandleClient(Socket sk)
        {
            string ipClient = sk.RemoteEndPoint.ToString();
            ListClient.Add(sk);
            Console.WriteLine(ipClient + " connect server call");
            XuLyMessage(sk);
            sk.Close();
            ListClient.Remove(sk);
            Console.WriteLine(ipClient + " disconnect server call");
        }
        public void XuLyMessage(Socket sk)
        {
            NetworkStream stream = new NetworkStream(sk);
            var reader = new StreamReader(stream);
            var writer = new StreamWriter(stream);
            writer.AutoFlush = true;
            string ID = null;
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
                        //Console.WriteLine(msg);
                        if (msg != null && msg.Contains("#SendID"))
                        {
                            string []str = msg.Split(' ');
                            ListID.Add(str[1]);
                            ID = str[1];
                        }                               

                        else if (msg != null && msg.Contains("#SendCallTo"))
                        {
                            string[] str = msg.Split(' ');
                            Console.WriteLine("ID: "+str[1]);
                            for (int i=0; i<ListID.Count; i++)
                            {
                                if(ListID[i].Equals(str[1]))
                                {
                                    string ipgroup = ID + ListID[i];
                                    
                                    ListIPGroup.Add(ipgroup);

                                    string msgSend = "#MakeCall: " + ID+ " "+sk.RemoteEndPoint.ToString()+" "+ ipgroup;
                                    Console.WriteLine("IPsend: " + sk.RemoteEndPoint.ToString() + " To:" + str[1]);
                                    var streamsend= new NetworkStream(ListClient[i]);
                                    var writersend = new StreamWriter(streamsend);
                                    writersend.WriteLine(msgSend);
                                    writersend.AutoFlush = true;
                                    break;
                                }    
                            }    
                        }
                        //msg= #AcceptCall: ip
                        else if (msg != null && msg.Contains("#AcceptCall"))
                        {
                            string[] str = msg.Split(' ');
                            Console.WriteLine(msg);
                            for (int i = 0; i < ListClient.Count; i++)
                            {
                                if (ListClient[i].RemoteEndPoint.ToString().Equals(str[1]))
                                {
                                    string ipgroup = str[2];

                                    //Console.WriteLine("IPsend: " + sk.RemoteEndPoint.ToString() +" To:"+ str[1]);
                                    string msgSend = "#AcceptCall: " + sk.RemoteEndPoint.ToString()+" "+ ipgroup;
                                    var streamsend = new NetworkStream(ListClient[i]);

                                    var writersend = new StreamWriter(streamsend);
                                    writersend.WriteLine(msgSend);
                                    Console.WriteLine(ListClient[i].RemoteEndPoint.ToString());
                                    writersend.AutoFlush = true;
                                    while (true)
                                    {
                                        try
                                        {
                                            if (!ListIPGroup.Contains(ipgroup))
                                            {
                                                string end = "#EndCall" ;
                                                writer.WriteLine(end);
                                                Console.WriteLine("#AcceptCall");
                                                break;
                                            }    
                                                
                                            else
                                            {
                                                byte[] buffer = new byte[2024];
                                                stream.Read(buffer, 0, 2024);
                                                streamsend.Write(buffer, 0, 2024);
                                            }                                           
                                        }
                                        catch(Exception ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                            break;
                                        }
                                    }    
                                    break;
                                }
                            }
                        }
                        //msg= #AcceptFinal: ip ipgroup
                        else if (msg != null && msg.Contains("#AcceptFinal"))
                        {
                            string[] str = msg.Split(' ');
                            Console.WriteLine(msg);
                            string ipgroup = str[2];
                            
                            for (int i = 0; i < ListClient.Count; i++)
                            {
                                if (ListClient[i].RemoteEndPoint.ToString().Equals(str[1]))
                                {
                                    var streamsend = new NetworkStream(ListClient[i]);
                                    while (true)
                                    {
                                        try
                                        {
                                            if (!ListIPGroup.Contains(ipgroup))
                                            {
                                                string end = "#EndCall";
                                                writer.WriteLine(end);
                                                Console.WriteLine("#AcceptFinal");
                                                break;
                                            }                                                  
                                            else
                                            {
                                                byte[] buffer = new byte[2024];
                                                stream.Read(buffer, 0, 2024);
                                                streamsend.Write(buffer, 0, 2024);
                                            }    
                                            
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }
                        }    

                        else
                            continue;
                    }
                }
                catch (Exception e)
                {
                    stream.Close();
                    Console.WriteLine(e.Message);
                }
            }
            stream.Close();
        }
    }
}
