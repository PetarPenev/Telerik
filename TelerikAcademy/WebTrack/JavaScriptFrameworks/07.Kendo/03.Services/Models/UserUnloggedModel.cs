using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace _03.Services.Models
{
    [DataContract]
    public class UserUnloggedModel
    {
        [DataMember(Name = "username")]
        public string Username { get; set; }

        [DataMember(Name = "authCode")]
        public string AuthCode { get; set; }
    }
}