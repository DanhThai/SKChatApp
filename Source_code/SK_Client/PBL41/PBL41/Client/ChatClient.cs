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
        private List<string> list;
        public static ChatClient instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new ChatClient();
                return _Instance;
            }
        }
        public void ConnectSV()
        {
            try
            {
                client = new TcpClient();
                client.Connect("127.0.0.1", 2001);
                stream = client.GetStream();
                Console.WriteLine("Kết nối tới server");
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
        public object DeserializeData(byte[] theByteArray)
        {
            BinaryFormatter bf1 = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(theByteArray);      
            ms.Position = 0;
            return bf1.Deserialize(ms);
        }
        public List<string> getList()
        {
            return list;
        }
        public string ReceiveLogin()
        {
            //var reader = new StreamReader(stream);
            //string msg = reader.ReadLine();
            //str= Encoding.ASCII.GetBytes(msg);

            byte[] str= new byte[100000];
            stream.Read(str,0,(int)client.ReceiveBufferSize);           
            //Console.WriteLine(Encoding.ASCII.GetString(str));
            if (str != null)
            {               
                list = (List<string>)DeserializeData(str);
                return "true";
            }
            return "false";
        }
        public string ReceiveMsg()
        {
            var reader = new StreamReader(stream);
            string msg = reader.ReadLine();
            
            return msg;
        }

    }
}
