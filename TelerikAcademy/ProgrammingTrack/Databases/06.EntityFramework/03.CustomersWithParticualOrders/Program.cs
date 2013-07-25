using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.DatabaseContext;

namespace _03.CustomersWithParticualOrders
{
    class Program
    {
        static void Main()
        {
            NorthwindEntities northwindEntities = new NorthwindEntities();
            DateTime date = DateTime.Now;

            var customers =
                from order in northwindEntities.Orders
                where ((order.OrderDate != null) && (order.OrderDate.Value.Year == 1997)
                && (order.ShipCountry == "Canada"))
                select new
                {
                    CompanyName = order.Customer.CompanyName,
                    ContactName = order.Customer.ContactName
                };

            // This is done so that the same names are not listed more than once.
            customers = customers.Distinct();

            foreach (var customer in customers)
            {
                Console.WriteLine("Company name is {0} and contact name is {1}", customer.CompanyName, customer.ContactName);
            }
        }
    }
}
