using System;

namespace _13.ThreeTasksSolver
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome!");
            // Избираме опция чрез четене на число от конзолата.
            Console.WriteLine("Please enter 1 for number reversal, 2 for calculating the average and 3 for solving a linear equation.");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
                Reverse();
            else if (choice == 2)
                Average();
            else if (choice == 3)
                Equation();
            else
                Console.WriteLine("Invalid choice.");

        }

        static void Reverse()
        {
            int number = 0;
            bool check = false;
            while (!check)
            {
                Console.WriteLine("Please enter the number");
                check = int.TryParse(Console.ReadLine(), out number);
            }
            string current = Convert.ToString(number);
            string result="";
            while (current.Length != 1)
            {
                result += current[current.Length - 1];
                current = current.Substring(0, current.Length - 1);
            }
            result += current;
            Console.WriteLine("The reversed number is {0}.",result);
        }

        static void Average()
        {
            Console.WriteLine("Please enter each integer on a new line and enter a string that is not a number for ending.");
            string input = Console.ReadLine();
            int currentNumber=0,result=0,counter=0;
            // Потвтаряме до неуспешно парсване
            while (int.TryParse(input, out currentNumber))
            {
                result += currentNumber;
                counter++;
                input = Console.ReadLine();
            }
            if (counter!=0)
                Console.WriteLine("The average is {0}.",(float)result/counter);
            else
                Console.WriteLine("No valid integers were entered.");
            
        }

        static void Equation()
        {
            int a = 0, b = 0;
            // Четем коефициентите и решаваме уравнението.
            Console.WriteLine("Please enter the a coefficient.");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the b coefficient.");
            b = int.Parse(Console.ReadLine());
            Console.WriteLine("The equation is {0}*x+{1}=0.",a,b);
            if (a == 0)
            {
                if (b == 0)
                    Console.WriteLine("Every x is a solution.");
                else
                    Console.WriteLine("There is no solution");
            }
            else
                Console.WriteLine("The solution is {0}.",-(float)b/a);
        }


    }
}
