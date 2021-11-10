using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Friend
{
    [Serializable]
    public class friend
    {
        public int ID { get; set; }
        public string IP { get; set; }
        public bool UpdateIP { get; set; }
        public string Name { get; set; }
        public friend(int id, string ip, string name)
        {
            ID = id;
            IP = ip;
            Name = name;
            UpdateIP = false;
        }
        public friend(int id, string ip)
        {
            ID = id;
            IP = ip;
            Name = null;
            UpdateIP = false;
        }
    }
}
