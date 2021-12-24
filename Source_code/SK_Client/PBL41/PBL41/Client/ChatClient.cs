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
        private List<ListMessage> listMS=new List<ListMessage>();
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
        public List<ListMessage> getListMessage()
        {
            return listMS;
        }
        public void addMessage(string msg,int id)
        {
            foreach (ListMessage i in listMS)
            {
                if (i.ID == id)
                {
                    i.addMessage(msg);
                    break;
                }
            }
        }
        public void addFriend(friend fr)
        {
            listFriend.Insert(0, fr);
            ListMessage lms = new ListMessage(fr.ID);
            listMS.Add(lms);
        }
        public void ConnectSV()
        {
            try
            {
                client = new TcpClient();
                client.Connect("192.168.1.201", 2001);
                stream = client.GetStream();

               

                listFriend = new List<friend>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                client.Connect("192.168.1.201", 2001);
                stream = client.GetStream();
            }
        }
        public void Disconnect()
        {
            if (client != null)
            {
                //var writer = new StreamWriter(stream);
                //writer.AutoFlush = true;
                //writer.WriteLine("#Disconnect");

                string msg = "#Disconnect";
                byte[] bytes = SerializeData(msg);
                stream.Write(bytes, 0, bytes.Length);

                stream.Close();
                client.Close();
                listFriend.Clear();
            }
        }
        

        /// <summary>
        ///  CHAT
        /// </summary>

        public void SendMsg(string msg)
        {
            try
            {
                //var writer = new StreamWriter(stream);
                //writer.AutoFlush = true;
                ////writer.WriteLine("#ip: " + ip + " #msg: " + msg);
                //writer.WriteLine(msg);
                
                byte[] bytes = SerializeData(msg);
                stream.Write(bytes, 0, bytes.Length);
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
                //var writer = new StreamWriter(stream);
                //writer.AutoFlush = true;
                //writer.WriteLine("#Login: " + user + " " + pass);
                string msg = "#Login: " + user + " " + pass;
                byte[] bytes = SerializeData(msg);
                stream.Write(bytes, 0, bytes.Length);
            }
            catch (Exception ex)
            {}
        }
        public void SendSearch(string name)
        {
            try
            {
                //var writer = new StreamWriter(stream);
                //writer.AutoFlush = true;
                //writer.WriteLine("#Search: " + name);
                string msg = "#Search: " + name;
                byte[] bytes = SerializeData(msg);
                stream.Write(bytes, 0, bytes.Length);
            }
            catch (Exception ex)
            {}
        }
        public void SendAddFriend(string id, string ip)
        {
            try
            {
                //var writer = new StreamWriter(stream);
                //writer.AutoFlush = true;
                //// msg= "#AddFriend: id ip"
                //writer.WriteLine("#AddFriend: " + id + " " + ip);
                string msg = "#AddFriend: " + id + " " + ip;
                byte[] bytes = SerializeData(msg);
                stream.Write(bytes, 0, bytes.Length);
            }
            catch (Exception ex)
            {}
        }
        public void SendAcceptFriend(string ip)
        {
            try
            {
                //var writer = new StreamWriter(stream);
                //writer.AutoFlush = true;
                ////msg="#AcceptFriend: ip"
                //writer.WriteLine("#AcceptFriend: " + ip);
                string msg = "#AcceptFriend: " + ip;
                byte[] bytes = SerializeData(msg);
                stream.Write(bytes, 0, bytes.Length);
            }
            catch (Exception ex)
            {}
        }
        public void SendAcc(String user, String pass)
        {
            try
            {
                //var writer = new StreamWriter(stream);
                //writer.AutoFlush = true;
                //writer.WriteLine("#ChangePass: " + user + " " + pass);
                string msg = "#ChangePass: " + user + " " + pass;
                byte[] bytes = SerializeData(msg);
                stream.Write(bytes, 0, bytes.Length);
            }
            catch (Exception ex)
            {}
        }

        public void SendSignUp(string user, string pass, string name, Boolean gender, DateTime date)
        {
            try
            {
                //var writer = new StreamWriter(stream);
                //writer.AutoFlush = true;
                //writer.WriteLine("#SignUp: " + user + " " + pass + " " + name + " " + gender + " " + date);
                string msg = "#SignUp: " + user + " " + pass + " " + name + " " + gender + " " + date;
                byte[] bytes = SerializeData(msg);
                stream.Write(bytes, 0, bytes.Length);
            }
            catch (Exception ex) { }
        }

        public void SendEndCall()
        {
            try
            {
                string ipgroup = CallClient.instance.ipgroup;
                //Console.WriteLine("ipgroup:" + ipgroup);
                //var writer = new StreamWriter(stream);
                //writer.AutoFlush = true;               
                //writer.WriteLine("#EndCall: "+ipgroup);
                string msg = "#EndCall: " + ipgroup;
                byte[] bytes = SerializeData(msg);
                stream.Write(bytes, 0, bytes.Length);
            }
            catch (Exception ex) { }
        }
        /// <summary>
        ///     RECEIVE MESSAGE
        /// </summary>  
       
        public object DeserializeData(byte[] theByteArray)
        {
            BinaryFormatter bf1 = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(theByteArray);      
            ms.Position = 0;
            return bf1.Deserialize(ms);
        }
        public byte[] SerializeData(object ob)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf1 = new BinaryFormatter();
            bf1.Serialize(ms, ob);
            return ms.ToArray();
        }

        public List<friend> ReceiveFriend()
        {
            List<friend> listFr = new List<friend>();
            listFr.Clear();
            while (true)
            {
                byte[] str = new byte[1024];
                int i = stream.Read(str, 0, 1024);
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
            foreach (friend i in listFriend)
            {
                ListMessage lms = new ListMessage(i.ID);
                listMS.Add(lms);
            }
            if (listFriend.Count > 0)
            {
                byte[] str = new byte[1024];
                stream.Read(str, 0, 1024);
                string s = Encoding.ASCII.GetString(str);
                Console.WriteLine(s);
                Information info= (Information)DeserializeData(str);
                InforUser.instance.SetInformation(info.ID,info.Full_name, info.Gender, info.Birthday);

                CallClient.instance.sendID();
                return true;
            }    
                
            else return false;
        }
        //search friend
        public List<friend> checkFriend()
        {
            List<friend>  list = ReceiveFriend();
            return list;
        }
        public friend makeFriend()
        {
            byte[] str = new byte[1024];
            int i = stream.Read(str, 0, 1024);
            string s = Encoding.ASCII.GetString(str);
            Console.WriteLine(s);
            friend fr = (friend)DeserializeData(str);
            return fr;
        }
        public string ReceiveMsg()
        {
            //var reader = new StreamReader(stream);
            //string msg = reader.ReadLine();
            byte[] data = new byte[1024];
            stream.Read(data, 0, 1024);
            string msg = (string)DeserializeData(data);

            Console.WriteLine("msg:" + msg);
            if(msg.Contains("#UpdateIP"))
            {
                // msg= "#UpdateIP: id ipnew"
                string[] str = msg.Split(new string[] { " " }, StringSplitOptions.None);
                //Console.WriteLine("ok:" + str[1] + " | " + str[2]);
                for (int i = 0; i < listFriend.Count; i++)
                {                   
                    if (listFriend[i].ID ==Convert.ToInt32(str[1]))
                    {
                        listFriend[i].IP = str[2];
                        listFriend[i].UpdateIP = true;
                        break;
                    }
                }
            }
            return msg;
        }

    }
}
