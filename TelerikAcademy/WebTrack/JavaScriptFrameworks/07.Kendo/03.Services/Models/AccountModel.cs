using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace _03.Services.Models
{
    [DataContract]
    public class AccountModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "sum")]
        public decimal Sum { get; set; }

        [DataMember(Name = "balance")]
        public decimal Balance { get; set; }
    }
}