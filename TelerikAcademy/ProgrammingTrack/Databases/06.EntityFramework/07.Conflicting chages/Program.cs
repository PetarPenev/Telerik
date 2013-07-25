using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.DatabaseContext;

namespace _07.Conflicting_chages
{
    public class Program
    {
        public static void ModifyCustomer(NorthwindEntities northwindEntities, string customerId, string companyName = null, string contactName = null, string address = null,
            string city = null, string region = null, string postalCode = null, string country = null, string phone = null,
            string fax = null)
        {
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
        }

        public static void Main()
        {
            NorthwindEntities firstContext = new NorthwindEntities();
            NorthwindEntities secondContext = new NorthwindEntities();

            ModifyCustomer(firstContext, "ALFKI", city: "Moscow");
            ModifyCustomer(secondContext, "ALFKI", city: "London");

            // Since database is not locked, the last modification will be the one to remain. According to MSDN:
            // http://msdn.microsoft.com/en-us/library/bb739065.aspx SaveChanges(boolean) is obsolete and should
            // not be used.
            firstContext.SaveChanges();
            secondContext.SaveChanges();

            firstContext.Dispose();
            secondContext.Dispose();
        }
    }
}