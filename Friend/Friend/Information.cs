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
        public string ID { get; set; }
        public string Full_name { get; set; }
        public bool Gender { get; set; }
        public DateTime Birthday { get; set; }
        public Information(string id, string name,bool gd,DateTime brth)
        {
            ID = id;
            Full_name = name;
            Gender = gd;
            Birthday = brth;
        }

    }
}
