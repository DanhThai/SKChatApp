using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PBL41.Client
{
    class ChatClient
    {
        private TcpClient client;
        private NetworkStream stream;
        private static ChatClient _Instance;
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
        public string ReceiveLogin()
        {
            var reader = new StreamReader(stream);
            string msg = reader.ReadLine();
            return msg;
        }
        public string ReceiveMsg()
        {
            var reader = new StreamReader(stream);
            string msg = reader.ReadLine();
            return msg;
        }

    }
}
