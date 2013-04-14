using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ManagerAndCompanyInfo
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Company Name:");
            string compName = Console.ReadLine();
            Console.WriteLine("Company Address:");
            string compAddress = Console.ReadLine();
            Console.WriteLine("Company Phone Number:");
            string compPhone = Console.ReadLine();
            Console.WriteLine("Company Fax:");
            string compFax = Console.ReadLine();
            Console.WriteLine("Company Web Site:");
            string compSite = Console.ReadLine();
            Console.WriteLine("Company Manager:");
            string compManager = Console.ReadLine();
            Console.WriteLine("Manager First Name:");
            string manFirstName = Console.ReadLine();
            Console.WriteLine("Manager Last Name:");
            string manLastName = Console.ReadLine();
            Console.WriteLine("Manager Age:");
            string manAge = Console.ReadLine();
            Console.WriteLine("Manager Phone:");
            string manPhone = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine( "The company's name is {0}, its address is {1}, the phone is {2}, the fax is {3}, the web site is {4} and the manager is {5}.", compName, compAddress, compPhone,compFax,compSite,compManager);
            Console.WriteLine();
            Console.WriteLine("The manager's first name is {0}, their last name is {1}, their age is {2} and their phone is {3}.", manFirstName, manLastName, manAge, manPhone);
        }
    }
}
