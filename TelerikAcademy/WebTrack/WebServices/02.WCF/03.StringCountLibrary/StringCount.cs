using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _03.StringCountLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class StringCount : IStringCount
    {

        public int GetStringCount(string containedString, string containeeString)
        {
            int numberOfOccurances = 0;
            int index = containeeString.IndexOf(containedString);

            while (index != -1)
            {
                numberOfOccurances++;
                index = containeeString.IndexOf(containedString, index + 1);
            }

            return numberOfOccurances;
        }
    }
}
