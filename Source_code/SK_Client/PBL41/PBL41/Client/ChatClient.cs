using Friend;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace PBL41.Client
{
    class ChatClient
    {
        private TcpClient client;
        private NetworkStream stream;
        private static ChatClient _Instance;
        private List<friend> listFriend;
        public static ChatClient instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new ChatClient();
                return _Instance;
            }
        }
        public List<friend> getListFriend()
        {
            return listFriend;
        }
        public void addFriend(friend fr)
        {
            listFriend.Insert(0, fr);
        }
        public void ConnectSV()
        {
            try
            {
                client = new TcpClient();
                client.Connect("127.0.0.1", 2001);
                stream = client.GetStream();
                Console.WriteLine("Kết nối tới server");
                listFriend = new List<friend>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                client.Connect("127.0.0.1", 2001);
                stream = client.GetStream();
            }
        }
        public void SendMsg(string msg)
        {
            try
            {
                var writer = new StreamWriter(stream);
                writer.AutoFlush = true;
                //writer.WriteLine("#ip: " + ip + " #msg: " + msg);
                writer.WriteLine(msg);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void SendLogin(string user, string pass)
        {
            try
            {
                var writer = new StreamWriter(stream);
                writer.AutoFlush = true;
                writer.WriteLine("#Login: " + user + " " + pass);
            }
            catch (Exception ex)
            {

            }
        }
        public void SendSearch(string name)
        {
            try
            {
                var writer = new StreamWriter(stream);
                writer.AutoFlush = true;
                writer.WriteLine("#Search: " + name);
            }
            catch (Exception ex)
            {

            }
        }
        public object DeserializeData(byte[] theByteArray)
        {
            BinaryFormatter bf1 = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(theByteArray);      
            ms.Position = 0;
            return bf1.Deserialize(ms);
        }
        
        
        public List<friend> ReceiveFriend()
        {
            List<friend> listFr = new List<friend>();
            while (true)
            {
                byte[] str = new byte[100000];
                int i = stream.Read(str, 0, (int)client.ReceiveBufferSize);
                string s = Encoding.ASCII.GetString(str);
                Console.WriteLine(s);
                if (i > 0)
                {                  
                    if (s.Contains("#false"))
                    {
                        break;
                    }
                    else if (s.Contains("#done"))
                    {
                        break;
                    }                         
                    else
                    {
                        friend fr = (friend)DeserializeData(str);
                        listFr.Add(fr);                     
                    }                   
                }
                else
                    break;
            }
            return listFr;
        }
        public bool checkLogin()
        {
            listFriend=ReceiveFriend();
            if (listFriend.Count > 0)
                return true;
            else return false;
        }
        //search friend
        public List<friend> checkFriend()
        {
            List<friend>  list =ReceiveFriend();
            return list;
        }
        public string ReceiveMsg()
        {
            var reader = new StreamReader(stream);
            string msg = reader.ReadLine();
            if(msg.Contains("#UpdateIP"))
            {
                // msg= "#msg #UpdateIP: ip ipnew"
                string[] str = msg.Split(new string[] { " " }, StringSplitOptions.None);
                for (int i = 0; i < listFriend.Count; i++)
                {                   
                    if (listFriend[i].ID ==Convert.ToInt32(str[2]))
                    {
                        listFriend[i].IP = str[3];
                        listFriend[i].UpdateIP = true;
                        break;
                    }
                }
            }
            return msg;
        }

    }
}
