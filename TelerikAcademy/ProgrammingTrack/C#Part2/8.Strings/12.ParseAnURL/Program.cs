using System;

/* Write a program that parses an URL address */

namespace _12.ParseAnURL
{
    class Program
    {
        static void Main()
        {
            // Следва се точно алгоритъма на зададената спецификация.
            Console.WriteLine("Please enter the url.");
            string address = Console.ReadLine();
            address=address.Trim();
            string protocol="", server="", resource="";
            if (address.IndexOf("://") != -1)
            {
                protocol = address.Substring(0, address.IndexOf("://"));
                address = address.Substring(address.IndexOf("://") + 3);
            }
            if (address.IndexOf("/") != -1)
            {
                server = address.Substring(0, address.IndexOf("/"));
                address = address.Substring(address.IndexOf("/"));
            }
            resource = address;
            if (protocol!=String.Empty)
                Console.WriteLine("[protocol] = \"{0}\"", protocol);
            if (server != String.Empty)
                Console.WriteLine("[server] = \"{0}\"", server);
            if (resource != String.Empty)
                Console.WriteLine("[resource] = \"{0}\"", resource);

        }
    }
}
