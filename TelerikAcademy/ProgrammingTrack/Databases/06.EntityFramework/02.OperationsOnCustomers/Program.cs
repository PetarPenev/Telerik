using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.DatabaseContext;

namespace _02.OperationsOnCustomers
{
    public class Program
    {
        public static void Main()
        {
            CustomerModifier.InsertCustomer("ABBA", "Swedish Record Company");
            CustomerModifier.ModifyCustomer("ALFKI", city: "Bonn");
            CustomerModifier.DeleteCustomer("ABBA");
        }
    }
}