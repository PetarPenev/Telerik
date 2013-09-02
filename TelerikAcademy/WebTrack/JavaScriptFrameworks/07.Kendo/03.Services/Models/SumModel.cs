using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace _03.Services.Models
{
    [DataContract]
    public class SumModel
    {
        [DataMember(Name = "sum")]
        public decimal Sum { get; set; }
    }
}