using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string AuthCode { get; set; }

        public string SessionKey { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }

        public User()
        {
            this.Accounts = new HashSet<Account>();
            this.Transactions = new HashSet<Transaction>();
        }
    }
}
