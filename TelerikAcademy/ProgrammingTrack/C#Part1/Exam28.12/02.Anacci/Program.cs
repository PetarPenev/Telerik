using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Anacci
{
    class Program
    {
        static void Main()
        {
            char firstChar, secondChar,intermediateChar;
            int l,numberElements,intermediateNumber;
            string output;
            firstChar = char.Parse(Console.ReadLine());
            secondChar = char.Parse(Console.ReadLine());
            l = int.Parse(Console.ReadLine());
            numberElements = l * 2 - 1;
            for (int i=0;i<l;i++)
            {
                if (i==0)
                {
                    Console.WriteLine(firstChar);
                }
                if (i==1)
                {
                    intermediateNumber = ((firstChar - 'A' + 1) + (secondChar - 'A' + 1));
                    if (intermediateNumber != 26)
                        intermediateNumber %= 26;
                    intermediateChar = Convert.ToChar('A' + intermediateNumber - 1);
                    Console.WriteLine("{0}{1}",secondChar,intermediateChar);
                    firstChar = secondChar;
                    secondChar = intermediateChar;
                }
                if (i>1)
                {
                    intermediateNumber = ((firstChar - 'A' + 1) + (secondChar - 'A' + 1));
                    if (intermediateNumber != 26)
                        intermediateNumber %= 26;
                    intermediateChar = Convert.ToChar('A' + intermediateNumber - 1);
                    output = Convert.ToString(intermediateChar);
                    output += new string(' ', i - 1);
                    firstChar = secondChar;
                    secondChar = intermediateChar;
                    intermediateNumber = ((firstChar - 'A' + 1) + (secondChar - 'A' + 1));
                    if (intermediateNumber != 26)
                        intermediateNumber %= 26;
                    intermediateChar = Convert.ToChar('A' + intermediateNumber - 1);
                    output += Convert.ToString(intermediateChar);
                    Console.WriteLine(output);
                    firstChar = secondChar;
                    secondChar = intermediateChar;
                }
                }
            }
        }
    }

