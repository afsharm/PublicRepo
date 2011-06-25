using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to WCF Server");

            ServiceManager.StartService();

            Console.WriteLine("Press RETURN to stop server");
            Console.ReadLine();
        }
    }
}
