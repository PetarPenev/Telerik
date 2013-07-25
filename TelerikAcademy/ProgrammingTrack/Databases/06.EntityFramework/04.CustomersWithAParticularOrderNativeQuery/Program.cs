using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.DatabaseContext;

namespace _04.CustomersWithAParticularOrderNativeQuery
{
    public class Program
    {
        public static void Main()
        {
            NorthwindEntities northwindEntities = new NorthwindEntities();
            string nativeSqlQuery = "SELECT DISTINCT c.CompanyName + ' represented by ' + c.ContactName " +
                "FROM dbo.Customers c JOIN dbo.Orders o ON c.CustomerID = o.CustomerID " +
                "WHERE o.ShipCountry = {0} AND o.OrderDate IS NOT NULL AND YEAR(o.OrderDate) = {1}";

            object[] parameters = { "Canada", 1997 };

            var customers = northwindEntities.Database.SqlQuery<string>(nativeSqlQuery, parameters);

            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }
        }
    }
}