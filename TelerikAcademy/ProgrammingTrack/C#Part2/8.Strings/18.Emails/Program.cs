using System;
using System.Text;
using System.Text.RegularExpressions;

/* Write a program for extracting all email addresses from given text. 
 * All substrings that match the format <identifier>@<host>…<domain> should be recognized as emails.*/


namespace _18.Emails
{
    class Program
    {
        static void Main()
        {
            // Използвам съм регулярен израз. Тъй като има различни спецификации за това какво е валиден имейл, съм се
            // придържал към моята и недобре специфицираната такава в условието на задачата.
            string text = "Please contact us by phone (+359 222 222 222) or by email at example@abv.bg or at baj.ivan@yahoo.co.uk. This is not email: test@test. This also: @telerik.com. Neither this: a@a.b.";
            MatchCollection collection;
            collection = Regex.Matches(text, @"\b[\w\d\.%]+?@[\w\d]+?\.(([\w]{2}\.[\w]{2,4})|[\w]{2,4})\b");
            foreach (Match match in collection)
                foreach (Capture capture in match.Captures)
                    Console.WriteLine(capture.Value);
        }
    }
}
