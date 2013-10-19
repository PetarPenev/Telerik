using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _01.Calculator.Models
{
    public class CalculatorModel
    {
        public List<string> ValueOptions = new List<string>()
        {
            //new String[]{
            "bit",
            "Byte",
            "Kilobit",
            "Kilobyte",
            "Megabit",
            "Megabyte",
            "Gigabit",
            "Gigabyte",
            "Terabit",
            "Terabyte",
            "Petabit",
            "Petabyte",
            "Exabit",
            "Exabyte",
            "Zettabit",
            "Zettabyte",
            "Yottabit",
            "Yottabyte"//}
        };

        public double[] DataValues = new double[18];
    }
}