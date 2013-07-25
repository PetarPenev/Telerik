using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenAccessModel3;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Telerik.OpenAccess;
using System.Diagnostics;

namespace TestApp
{
    class Program
    {
        private static void SerializeDeserialize()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            MemoryStream stream = SerializeToBinaryStream("ALFKI");
            stream.Seek(0, SeekOrigin.Begin);

            Customer customer = formatter.Deserialize(stream) as Customer;

            Console.WriteLine("Country: {0}", customer.Country);
        }

        private static MemoryStream SerializeToBinaryStream(string customerId)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            MemoryStream stream = new MemoryStream();

            using (EntitiesModel dbContext = new EntitiesModel())
            {
                Customer customer = dbContext.Customers.Where(c => c.CustomerID == customerId).First();
                formatter.Serialize(stream, customer);
            }

            return stream;
        }

        private static void BulkInsert()
        {
            using (EntitiesModel context = new EntitiesModel())
            {
                List<Product> productsNew = new List<Product>();
                for (int i = 0; i < 1000; i++)
                {
                    productsNew.Add(new Product() { Discontinued = false, ProductName = "Product" + i });
                }

                context.Add(productsNew);
                context.SaveChanges();
            }
        }

        private static TimeSpan SlowDelete()
        {
            using (EntitiesModel context = new EntitiesModel())
            {
                Stopwatch watch = new Stopwatch();

                var customersToRemove = from product in context.Products
                                        where (product.ProductID > 80)
                                        select product;

                watch.Start();
                context.Delete(customersToRemove);
                //context.Delete(context.Products.Where(p => p.ProductID % 7 == 2 && p.ProductID > 80));
                context.SaveChanges();
                watch.Stop();

                return watch.Elapsed;
            }
        }

        static void Main()
        {
            // Task 1
            Customer customer = new Customer();
            customer.PropertyChanged += Write;
            customer.Address = "ba";

            // Task 2
            var serializedStream = SerializeToBinaryStream("ALFKI");

            // Task 3
            BulkInsert();
            TimeSpan timeToDeleteSlow = SlowDelete();

            using (EntitiesModel context = new EntitiesModel())
            {
                var query = from product in context.Products
                            where (product.SupplierID == null)
                            select customer;

                query.DeleteAll();
            }
        }

        private static void Write(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Console.WriteLine(e.PropertyName);
        }
    }
}