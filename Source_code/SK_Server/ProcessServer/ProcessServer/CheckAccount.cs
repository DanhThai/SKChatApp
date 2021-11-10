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
    class CheckAccount
    {
        private List<friend> listClient = new List<friend>();
        private static CheckAccount _Instance;
        
        public static CheckAccount instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new CheckAccount();
                return _Instance;
            }
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
                List<byte[]> listfr = list.getFriend();
                //listfr.Add(getInfor((int)acc.Id,ip));
                return listfr;
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
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf1 = new BinaryFormatter();
            bf1.Serialize(ms, (object)infor);
            return ms.ToArray();
        }
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
        public void addClient(int id, string ip )
        {
            friend fr = new friend(id,ip);
            listClient.Add(fr);
        }
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
