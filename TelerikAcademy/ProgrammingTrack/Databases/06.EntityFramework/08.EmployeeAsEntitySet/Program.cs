using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.DatabaseContext;

namespace _08.EmployeeAsEntitySet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (NorthwindEntities northwindEntities = new NorthwindEntities())
            {
                foreach (var entity in northwindEntities.Employees)
                {
                    foreach (var item in entity.TerritoriesEntitySet)
                    {
                        Console.WriteLine(item.TerritoryDescription);
                    }
                }
            }
        }
    }
}