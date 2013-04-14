using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.CardNames
{
    class Program
    {
        static void Main()
        {
            string name = "";
            string color = "";
            for (int i = 1; i <= 13; i++)
            {
                switch (i)
                {
                    case 1:
                        name = "Two";
                        break;
                    case 2:
                        name = "Three";
                        break;
                    case 3:
                        name = "Four";
                        break;
                    case 4:
                        name = "Five";
                        break;
                    case 5:
                        name = "Six";
                        break;
                    case 6:
                        name = "Seven";
                        break;
                    case 7:
                        name = "Eight";
                        break;
                    case 8:
                        name = "Nine";
                        break;
                    case 9:
                        name = "Ten";
                        break;
                    case 10:
                        name = "Jack";
                        break;
                    case 11:
                        name = "Queen";
                        break;
                    case 12:
                        name = "King";
                        break;
                    case 13:
                        name = "Ace";
                        break;
                    default:
                        break;
                }
                for (int j = 1; j <= 4; j++)
                {
                    switch (j)
                    {
                        case 1:
                            color = "Spades";
                            break;
                        case 2:
                            color = "Hearts";
                            break;
                        case 3:
                            color = "Diamonds";
                            break;
                        case 4:
                            color = "Clubs";
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine("{0} {1}", name, color);
                }
            }
        }
    }
}
