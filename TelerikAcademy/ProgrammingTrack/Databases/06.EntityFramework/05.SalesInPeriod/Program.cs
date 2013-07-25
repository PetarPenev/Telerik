using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.DatabaseContext;
using System.Data.Entity.Infrastructure;

namespace _05.SalesInPeriod
{
    public class Program
    {
        public static void Main()
        {
            string regionName = "RJ";
            DateTime startDate = new DateTime(1997, 1, 1);
            DateTime endDate = new DateTime(1998, 1, 1);


            using (var northwindEntities = new NorthwindEntities())
            {
                var sales =
                    from finishedOrder in northwindEntities.Orders.Include("Order Details").Include("Products")
                    where ((finishedOrder.ShipRegion == regionName) && (finishedOrder.ShippedDate != null) &&
                        (DateTime.Compare(startDate, finishedOrder.ShippedDate.Value) <= 0)
                        && (DateTime.Compare(finishedOrder.ShippedDate.Value, endDate) <= 0))
                    select new
                    {
                        OrderDate = finishedOrder.OrderDate,
                        ShippedDate = finishedOrder.ShippedDate,
                        CompanyName = finishedOrder.Customer.CompanyName,
                        Details = finishedOrder.Order_Details,
                    };

                int counter = 0;
                foreach (var order in sales)
                {
                    counter++;
                    Console.WriteLine(GetOrderString(order));
                }

                Console.WriteLine(Environment.NewLine + counter + " finished sales found.");
            }
        }

        public static string GetOrderString(dynamic order)
        {
            StringBuilder orderInfo = new StringBuilder();
            orderInfo.AppendLine("Order started at " + order.OrderDate.ToString() + " and finished at " + order.ShippedDate.ToString());
            foreach (var orderDetail in order.Details)
            {
                orderInfo.AppendLine(orderDetail.Quantity + " units of " + orderDetail.Product.ProductName + " each costing " +
                    ((float)orderDetail.UnitPrice - orderDetail.Discount));
            }

            return orderInfo.ToString();
        }
    }
}