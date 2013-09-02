using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace _01.Services.Models
{
    [DataContract(Name = "mark")]
    public class Mark
    {
        [DataMember(Name = "subject")]
        public string Subject { get; set; }

        [DataMember(Name = "value")]
        public int Value { get; set; }
    }
}