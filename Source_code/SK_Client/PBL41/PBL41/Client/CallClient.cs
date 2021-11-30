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
        public void sendAcceptCall(string ip)
        {
            try
            {
                var writer = new StreamWriter(stream2);
                writer.AutoFlush = true;
                writer.WriteLine("#AcceptCall: " + ip);
            }
            catch (Exception ex)
            { }
        }
        public void sendAcceptFinal(string ip)
        {
            try
            {
                var writer = new StreamWriter(stream2);
                writer.AutoFlush = true;
                writer.WriteLine("#AcceptFinal: " + ip);
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

                return msg;
            }
            //#AcceptCall
            else
            {
                string[] str = msg.Split(' ');
                ipcall = str[1];
                sendAcceptFinal(ipcall);
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
            byte[] buffer = new byte[4048];
            try
            {
                
                stream2.Read(buffer, 0, 4048);
                
            }
            catch (Exception ex)
            { }
            return buffer;
        }
    }
}
