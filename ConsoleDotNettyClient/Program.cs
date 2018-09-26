using System;

namespace ConsoleDotNettyClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = Client.RunClientAsync();
            client.Wait();
            Console.ReadLine();
        }
    }
}
