using ConsoleDotNetty;
using System;

namespace ConsoleDotNettyServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = Server.RunServerAsync();

            server.Wait();

            Console.ReadLine();
        }
    }
}
