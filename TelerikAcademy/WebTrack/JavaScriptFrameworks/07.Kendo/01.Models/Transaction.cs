using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        public virtual User Owner { get; set; }

        public virtual Account Account { get; set; }

        public TransactionType TransactionType { get; set; }

        public decimal Amount { get; set; }
    }
}
