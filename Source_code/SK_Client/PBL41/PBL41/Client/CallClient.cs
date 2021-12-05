using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PBL41.Client
{
    class CallClient
    {
        private TcpClient client2;
        private NetworkStream stream2;
        private TcpClient client3;
        private NetworkStream stream3;
        private string ipcall;
        public string ipgroup=null;
        private static CallClient _Instance;

        public static CallClient instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new CallClient();
                return _Instance;
            }
        }
        public void ConnectSV()
        {
            try
            {
                client2 = new TcpClient();
                client2.Connect("192.168.1.201", 2002);
                stream2 = client2.GetStream();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void sendID()
        {
            try
            {
                string id = InforUser.instance.ID;
                var writer = new StreamWriter(stream2);
                writer.AutoFlush = true;
                writer.WriteLine("#SendID: " + id);
            }
            catch (Exception ex)
            {

            }
        }
        public void sendCallToID(string id)
        {
            try
            {
                var writer = new StreamWriter(stream2);
                writer.AutoFlush = true;
                writer.WriteLine("#SendCallTo: " + id);
            }
            catch (Exception ex)
            { }
        }
        public void sendAcceptCall(string ip,string ipgroup)
        {
            try
            {
                var writer = new StreamWriter(stream2);
                writer.AutoFlush = true;
                writer.WriteLine("#AcceptCall: " + ip+" "+ipgroup);
            }
            catch (Exception ex)
            { }
        }
        public void sendAcceptFinal(string ip,string ipgroup)
        {
            try
            {
                var writer = new StreamWriter(stream2);
                writer.AutoFlush = true;
                writer.WriteLine("#AcceptFinal: " + ip+" "+ipgroup);
            }
            catch (Exception ex)
            { }
        }
        public string receiveMsgCall()
        {
            var reader = new StreamReader(stream2);
            string msg = reader.ReadLine();
            Console.WriteLine("msg:" + msg);
            if (msg.Contains("#MakeCall"))
            {
                string[] str = msg.Split(' ');
                ipcall = str[2];
                ipgroup = str[3];
                return msg;
            }
            //#AcceptCall: ip
            else
            {
                string[] str = msg.Split(' ');
                ipcall = str[1];
                ipgroup = str[2];
               
                sendAcceptFinal(ipcall, ipgroup);
                return "#done";
            }
        }
        public void sendData(byte[] data)
        {
            try
            {
                stream2.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            { }
        }
        public byte[] receiveData()
        {
            byte[] buffer =new byte[2024];
            try
            {               
                stream2.Read(buffer, 0, 2024);                              
            }
            catch (Exception ex)
            {
                return null;
            }
            return buffer;
        }
    }
}
