using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exam.WebApp.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    public class StringDoesNotContainAttribute : ValidationAttribute
    {
        private string text;

        public StringDoesNotContainAttribute(string text)
        {
            this.text = text;
        }

        public override bool IsValid(object value)
        {
            string valueAsString = value as string;
            if (valueAsString == null)
            {
                return true;
            }

            return !valueAsString.ToLower().Contains(text.ToLower());
        }
    }
}