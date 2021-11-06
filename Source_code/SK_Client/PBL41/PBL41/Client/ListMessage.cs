using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL41.Client
{
    class ListMessage
    {
        public string Name{get; set;}
        public List<string> Message;
        public ListMessage(string name)
        {
            this.Name = name;
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
