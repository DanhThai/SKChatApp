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
            //test();
        }
        //public static void test()
        //{
        //    ListFriend l = new ListFriend();
        //    l.addFriend(1);
        //    List<byte[]> data = l.getFriend();
        //    string s= Encoding.ASCII.GetString(data[1]);
        //    Console.WriteLine(s);
        //}
    }
}
