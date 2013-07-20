namespace _02.ColorfulRabbits
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> rabbitAnswers = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                int rabbitAnswer = int.Parse(Console.ReadLine());
                if (rabbitAnswers.ContainsKey(rabbitAnswer))
                {
                    rabbitAnswers[rabbitAnswer] += 1;
                }
                else
                {
                    rabbitAnswers.Add(rabbitAnswer, 1);
                }
            }

            int minimalNumberOfRabbits = 0;
            foreach (var key in rabbitAnswers.Keys)
            {
                if (key == 0)
                {
                    minimalNumberOfRabbits += rabbitAnswers[key];
                }
                else if (key == 1)
                {
                    if (rabbitAnswers[key] % 2 == 0)
                    {
                        minimalNumberOfRabbits += rabbitAnswers[key];
                    }
                    else
                    {
                        minimalNumberOfRabbits += rabbitAnswers[key] + 1;
                    }
                }
                else
                {
                    int numberOfRabbitGroups = rabbitAnswers[key] / (key + 1);
                    if ((rabbitAnswers[key] % (key + 1)) != 0)
                    {
                        numberOfRabbitGroups += 1;
                    }

                    minimalNumberOfRabbits += (numberOfRabbitGroups) * (key + 1);
                }
            }

            Console.WriteLine(minimalNumberOfRabbits);
        }
    }
}