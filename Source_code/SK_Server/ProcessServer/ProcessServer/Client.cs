using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Friend;

namespace ProcessServer
{
    class Client
    {
        private List<friend> listClient = new List<friend>();
        private static Client _Instance;
        
        public static Client instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new Client();
                return _Instance;
            }
        }
        public byte[] SerializeData(object list)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf1 = new BinaryFormatter();
            bf1.Serialize(ms, (object)list);
            return ms.ToArray();
        }
        public List<byte[]> checkLogin(string user,string pass,string ip)
        {
            DB_Model db = new DB_Model();
            Account acc = db.Accounts.Find(user);

            if (acc!=null && acc.Pass == pass)
            {
                int id=(int)acc.Id;
                addClient(id, ip);

                ListFriend list = new ListFriend();                    
                list.addFriend(id);              
                // convert object to byte array
                List<byte[]> listfriend = list.getFriend();
                //listfr.Add(getInfor((int)acc.Id,ip));
                return listfriend;
            }                   
            return null;
        }
        public byte[] getInfor(int id,string ip)
        {
            DB_Model db = new DB_Model();
            Person ps = db.Person.Find(id);
            ps.Ipaddress = ip;
            db.SaveChanges();
            Information infor = new Information(ps.Id, ip, ps.Full_name, (bool)ps.Gender, Convert.ToDateTime( ps.Birthday));
            //MemoryStream ms = new MemoryStream();
            //BinaryFormatter bf1 = new BinaryFormatter();
            //bf1.Serialize(ms, (object)infor);
            return SerializeData(infor).ToArray();
        }
        public List<byte[]> searchFriend(string name)
        {
            List<byte[]> listFriend = new List<byte[]>();
            DB_Model db = new DB_Model();
            var listfr = from p in db.Person where p.Full_name.Contains(name) select new { p.Id,p.Ipaddress,p.Full_name };
            foreach (var i in listfr)
            {
                friend fr = new friend(i.Id, i.Ipaddress, i.Full_name);
                listFriend.Add(SerializeData(fr).ToArray());
            }
            return listFriend;
        }
        // add client connected to server
        public void addClient(int id, string ip)
        {
            friend fr = new friend(id, ip);
            listClient.Add(fr);
        }

        // get ip client connected to server
        public string checkIPbyID(int id)
        {
            string ip;
            for (int i = 0; i < listClient.Count; i++)
            {
                if (listClient[i].ID.Equals(id))
                {
                    ip = listClient[i].IP;
                    return ip;
                }
            }
            return null;
        }
        // get id client connected to server
        public int getIDbyIP(string ip)
        {
            int id;
            for(int i=0; i<listClient.Count;i++)
            {
                if(listClient[i].IP.Equals(ip))
                {
                    id = listClient[i].ID;
                    return id;
                }    
            }
            return 0;
        }
    }
}
