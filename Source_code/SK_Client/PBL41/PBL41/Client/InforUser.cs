using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL41.Client
{
    
    class InforUser
    {
        private static InforUser _Instance;
        public String User { get; set; }
        public String PassWord { get; set; }
        public String Name { get; set; }
        public bool Gender { get; set; }
        public DateTime Birthday { get; set; }
        public static InforUser instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new InforUser();
                return _Instance;
            }
        }

        public void SetAcc(String user, String pass)
        {
            User = user;
            PassWord = pass;
        }
        public void SetInformation(string name,bool gd, DateTime bth)
        {
            Name = name;
            Gender = gd;
            Birthday = bth;
        }
        public string getName()
        {
            string[] name = Name.Split(' ');
            return name[name.Length - 1];
        }
        
    }
}
