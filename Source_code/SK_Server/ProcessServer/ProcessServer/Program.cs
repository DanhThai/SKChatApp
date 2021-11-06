using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Server pg = new Server();
            pg.startServer();
        }
    }
}
