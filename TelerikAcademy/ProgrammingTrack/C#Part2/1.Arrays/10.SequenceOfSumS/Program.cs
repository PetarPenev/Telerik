using System;

/* Write a program that finds in given array of integers a sequence of given sum S (if present).
 * Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11  {4, 2, 5}*/
namespace _10.SequenceOfSumS
{
    class Program
    {
        static void Main()
        {
            /*  Задачата намира само първата такава последователност. Условието не изисква да се намират повече от една 
                последователност.
                Имаме променливи за стартовия индекс на последователността, за дължината й, за сумата s и булева променлива
                found за това дали сме намерили такава сума.*/
            int sum=0,startIndex,length,s=0;
            bool check = false,found=false;
            string result;
            int[] mass = new int[] { 4, 3, 1, 4, 2, 5, 8 };
            //Четем необходимите променливи.
            while (!check)
            {
                Console.WriteLine("Please enter S.");
                check = int.TryParse(Console.ReadLine(), out s);
            }
            // Започваме от нулевата променлива.
            startIndex=0;
            length=0;
            sum=0;
            // Въртим цикъла или докато не намерим сума, или докато сме обходили изцяло възможните последователности:
            // последната разглеждана последователност е тази, състояща се само от последния елемент.
            while ((!found) && (startIndex < mass.Length))
            {
                for (int i = startIndex; i < mass.Length; i++)
                {
                    sum += mass[i];
                    length += 1;
                    if (sum > s)
                    {
                        sum = 0;
                        length = 0;
                        break;
                    }
                    else if (sum == s)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                    startIndex += 1;
            }
            //Извеждаме резултата.
            if (!found)
                Console.WriteLine("No such sequence exists.");
            else
            {
                result = "{";
                for (int i = startIndex; i < startIndex + length; i++)
                    result += String.Format("{0} ", mass[i]);
                result += "}";
                Console.WriteLine(result);
            }
        }
    }
}
