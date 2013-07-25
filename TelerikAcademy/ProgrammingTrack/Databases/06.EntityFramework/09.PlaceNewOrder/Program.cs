using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.DatabaseContext;
using System.Transactions;

namespace _09.PlaceNewOrder
{
    public class Program
    {
        public static void InsertOrder(int shipperId, string customerId, int employeeId, string destionation)
        {
            using (NorthwindEntities northwindEntities = new NorthwindEntities())
            {
                try
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        Order orderToInsert = new Order
                        {
                            CustomerID = customerId,
                            EmployeeID = employeeId,
                            OrderDate = DateTime.Now,
                            RequiredDate = DateTime.Now.Add(new TimeSpan(100, 0, 0, 0)),
                            ShipVia = shipperId,
                            Freight = 3000000,
                            ShipCountry = destionation,
                            Customer = northwindEntities.Customers.FirstOrDefault(c => c.CustomerID == customerId),
                            Employee = northwindEntities.Employees.FirstOrDefault(e => e.EmployeeID == employeeId),
                            Shipper = northwindEntities.Shippers.FirstOrDefault(s => s.ShipperID == shipperId),
                            Order_Details = new HashSet<Order_Detail>()
                        };

                        orderToInsert.Order_Details.Add(new Order_Detail
                        {
                            ProductID = 2,
                            Quantity = 34,
                            Discount = 1,
                            Order = orderToInsert
                        });

                        orderToInsert.Order_Details.Add(new Order_Detail
                        {
                            ProductID = 3,
                            Quantity = 70,
                            Discount = 1,
                            Order = orderToInsert
                        });

                        orderToInsert.Order_Details.Add(new Order_Detail
                        {
                            ProductID = 4,
                            Quantity = 110,
                            Discount = 1,
                            Order = orderToInsert
                        });
                        
                        northwindEntities.Orders.Add(orderToInsert);                       

                        northwindEntities.SaveChanges();

                        scope.Complete();
                         //This ensures that the transaction has been completed.
                        int orderId = orderToInsert.OrderID;
                        Console.WriteLine(orderId);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void Main()
        {
            int shipperId = 2;
            string customerId = "BLONP";
            int employeeId = 8;
            string destination = "Quatar";
            InsertOrder(shipperId, customerId, employeeId, destination);         
        }
    }
}
