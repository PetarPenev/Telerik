using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02.Model.Classes;

namespace _03.Model.Data
{
    public class Context : DbContext
    {
        public Context()
            :base("BankDatabase")
        {
        }

        public DbSet<CardAccount> CardAccounts { get; set; }

        public DbSet<TransactionHistory> TransactionsHistory { get; set; }
    }
}
