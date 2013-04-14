using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.QuotedAndUnquotedStrings
{
    class Program
    {
        static void Main()
        {
            string quotedString, unquotedString;
            quotedString = @"The use of ""quotations"" causes difficulties.";
            unquotedString = "The use of \"quotations\" causes difficulties.";
            Console.WriteLine(quotedString);
            Console.WriteLine(unquotedString);

        }
    }
}
