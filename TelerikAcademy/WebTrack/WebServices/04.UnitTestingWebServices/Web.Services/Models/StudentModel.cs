﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Services.Models
{
    public class StudentModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public int Grade { get; set; }
    }
}