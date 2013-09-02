using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace _03.WebServices.Models
{
    [DataContract]
    public class MarkModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "subject")]
        public string Subject { get; set; }

        [DataMember(Name = "score")]
        public int Score { get; set; }
    }
}