using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace _01.Services.Models
{
    [DataContract(Name="student")]
    public class Student
    {
        [DataMember(Name="id")]
        public int Id { get; set; }

        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }

        [DataMember(Name = "lastName")]
        public string LastName { get; set; }

        [DataMember(Name = "grade")]
        public int Grade { get; set; }

        [DataMember(Name = "marks")]
        public List<Mark> Marks { get; set; }
    }
}