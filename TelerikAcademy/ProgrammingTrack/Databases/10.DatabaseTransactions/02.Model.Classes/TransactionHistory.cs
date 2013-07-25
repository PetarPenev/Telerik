using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _02.Model.Classes
{
    [Table("TransactionsHistory")]
    public class TransactionHistory
    {
        public int Id { get; set; }

        [StringLength(10)]
        public string CardNumber { get; set; }

        public DateTime TransactionDate { get; set; }

        public decimal Amount { get; set; }
    }
}
