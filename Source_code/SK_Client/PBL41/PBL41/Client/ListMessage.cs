using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL41.Client
{
    class ListMessage
    {
        public int ID{get; set;}
        public List<string> Message;
        public ListMessage(int id)
        {
            this.ID = id;
            this.Message = new List<string>();
        }

        public void addMessage(string ms)
        {
            this.Message.Add(ms);
        }
        public List<string> getMessage()
        {
            return Message;
        }

    }
}
