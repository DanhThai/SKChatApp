using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Friend
{
    [Serializable]
    public class Information
    {
        public int ID { get; set; }
        public string IPaddress { get; set; }
        public string Full_name { get; set; }
        public bool Gender { get; set; }
        public DateTime Birthday { get; set; }
        public byte[] Img { get; set; }
        public Information(int id,string ip,string name,bool gd,DateTime brth)
        {
            ID = id;
            IPaddress = ip;
            Full_name = name;
            Gender = gd;
            Birthday = brth;
            Img = null;
        }

    }
}
