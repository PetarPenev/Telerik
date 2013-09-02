using _01.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Data
{
    public class BankContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public BankContext() :
            base("BankDB")
        {
        }
    }
}
