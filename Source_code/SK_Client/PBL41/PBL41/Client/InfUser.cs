using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL41.Client
{
    
    class InfUser
    {
        private static InfUser _Instance;
        public String User { get; set; }
        public String PassWord { get; set; }
        public static InfUser instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new InfUser();
                return _Instance;
            }
        }

        public void SetAcc(String user, String pass)
        {
            User = user;
            PassWord = pass;
        }
        
    }
}
