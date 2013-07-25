using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.DatabaseContext;

namespace _02.OperationsOnCustomers
{
    public static class CustomerModifier
    {
        public static void InsertCustomer(string customerId, string companyName, string contactName = null, string address = null,
            string city = null, string region = null, string postalCode = null, string country = null, string phone = null, 
            string fax = null)
        {
            NorthwindEntities northwindEntities = new NorthwindEntities();

            int numberOfCustomersBefore =
                (from customer in northwindEntities.Customers
                select customer).Count();

            Customer customerToInsert = new Customer
            {
                CustomerID = customerId,
                CompanyName = companyName,
                Address = address,
                City = city,
                PostalCode = postalCode,
                Region = region,
                Country = country,
                Phone = phone,
                Fax = fax
            };

            northwindEntities.Customers.Add(customerToInsert);
            northwindEntities.SaveChanges();

            int numberOfCustomersAfter =
                (from customer in northwindEntities.Customers
                 select customer).Count();

            if (numberOfCustomersAfter - numberOfCustomersBefore == 1)
            {
                Console.WriteLine("Customer added successfully.");
            }
            else
            {
                throw new System.Data.EntityException("Incorrect insertion result.");
            }
        }

        public static void ModifyCustomer(string customerId, string companyName = null, string contactName = null, string address = null,
            string city = null, string region = null, string postalCode = null, string country = null, string phone = null,
            string fax = null)
        {
            NorthwindEntities northwindEntities = new NorthwindEntities();
            Customer customerToModify = northwindEntities.Customers.FirstOrDefault(c => c.CustomerID == customerId);
            if (customerToModify == null)
            {
                throw new System.Data.EntityException("No such customer exists.");
            }

            customerToModify.CompanyName = string.IsNullOrEmpty(companyName) ? customerToModify.CompanyName : companyName;
            customerToModify.ContactName = string.IsNullOrEmpty(contactName) ? customerToModify.ContactName : contactName;
            customerToModify.Address = string.IsNullOrEmpty(address) ? customerToModify.Address : address;
            customerToModify.City = string.IsNullOrEmpty(city) ? customerToModify.City : city;
            customerToModify.Region = string.IsNullOrEmpty(region) ? customerToModify.Region : region;
            customerToModify.PostalCode = string.IsNullOrEmpty(postalCode) ? customerToModify.PostalCode : postalCode;
            customerToModify.Country = string.IsNullOrEmpty(country) ? customerToModify.Country : country;
            customerToModify.Phone = string.IsNullOrEmpty(phone) ? customerToModify.Phone : phone;
            customerToModify.Fax = string.IsNullOrEmpty(fax) ? customerToModify.Fax : fax;

            northwindEntities.SaveChanges();
        }

        public static void DeleteCustomer(string customerId)
        {
            NorthwindEntities northwindEntities = new NorthwindEntities();
            Customer customerToDelete = northwindEntities.Customers.FirstOrDefault(c => c.CustomerID == customerId);
            if (customerToDelete == null)
            {
                throw new System.Data.EntityException("There is no such customer.");
            }

            northwindEntities.Customers.Remove(customerToDelete);
            northwindEntities.SaveChanges();
        }
    }
}