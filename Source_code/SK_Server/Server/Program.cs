using System;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerChat pg = new ServerChat();
            pg.ConnectSV();
        }
    }
}
