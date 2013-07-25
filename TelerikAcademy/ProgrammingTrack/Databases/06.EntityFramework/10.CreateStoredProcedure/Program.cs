using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.DatabaseContext;

namespace _10.CreateStoredProcedure
{
    public class Program
    {
        public static void Main()
        {
            // The script for generating the stored procedure is in the main folder for this project - 10.CreateStoredProcedure.
            // Warning: you must map the procedure to the name GetSupplierIncome via the database model: right-click on the model -
            // update, right-click again - add new - function import. I am enclosing (just in case) a script with my current version
            // of the database with the procedure in it in the project folder - you must still map though.
            using (NorthwindEntities northwindEntites = new NorthwindEntities())
            {
                Console.WriteLine((double)northwindEntites.GetSupplierIncome(1, new DateTime(1996, 7, 15), new DateTime(1996, 8, 24)).FirstOrDefault());  
            }
        }
    }
}