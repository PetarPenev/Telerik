using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace _03.Services.Models
{
    [DataContract]
    public class TransactionModel
    {
        [DataMember(Name="accountId")]
        public int AccountId { get; set; }

        [DataMember(Name="transactionType")]
        public string TransactionType { get; set; }

        [DataMember(Name="amount")]
        public decimal Amount { get; set; }
    }
}