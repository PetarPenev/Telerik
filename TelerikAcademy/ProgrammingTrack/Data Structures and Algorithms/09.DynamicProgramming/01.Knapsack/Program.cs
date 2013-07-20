namespace _01.Knapsack
{
    using System;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            Item[] itemsArray = new Item[6];
            itemsArray[0] = new Item("beer", 3, 2);
            itemsArray[1] = new Item("vodka", 8, 12);
            itemsArray[2] = new Item("cheese", 4, 5);
            itemsArray[3] = new Item("nuts", 1, 4);
            itemsArray[4] = new Item("ham", 2, 3);
            itemsArray[5] = new Item("whiskey", 8, 13);

            int maxWeight = 10;
            int[,] valueArray = new int[itemsArray.Length + 1, maxWeight + 1];
            bool[,] inclusionArray = new bool[itemsArray.Length + 1, maxWeight + 1];

            for (int i = 0; i < valueArray.GetLength(1); i++)
            {
                valueArray[0, i] = 0;
            }

            for (int i = 0; i < valueArray.GetLength(0); i++)
            {
                valueArray[i, 0] = 0;
            }

            for (int i = 1; i < valueArray.GetLength(0); i++)
            {
                for (int j = 1; j < valueArray.GetLength(1); j++)
                {
                    if (itemsArray[i - 1].Weight <= j)
                    {
                        if (valueArray[i - 1, j] > itemsArray[i - 1].Cost + valueArray[i - 1, j - itemsArray[i - 1].Weight])
                        {
                            int value = valueArray[i - 1, j];
                            valueArray[i, j] = value;
                        }
                        else
                        {
                            int value = itemsArray[i - 1].Cost + valueArray[i - 1, j - itemsArray[i - 1].Weight];
                            valueArray[i, j] = value;
                            inclusionArray[i, j] = true;
                        }
                    }
                }
            }

            int maxValue = valueArray[valueArray.GetLength(0) - 1, valueArray.GetLength(1) - 1];

            StringBuilder itemsIncluded = new StringBuilder("{");

            int item = itemsArray.GetLength(0);
            int currentWeight = maxWeight;
            while (item > 0)
            {
                if (inclusionArray[item, currentWeight])
                {
                    itemsIncluded.Append(itemsArray[item - 1] + ", ");
                    item--;
                    currentWeight -= itemsArray[item].Weight;
                }
                else
                {
                    item--;
                }
            }

            if (itemsIncluded[itemsIncluded.Length - 1] != '{')
            {
                itemsIncluded.Remove(itemsIncluded.Length - 2, 2);
            }

            itemsIncluded.Append("}");

            Console.WriteLine("The optimal set is: {0} and its value is {1}.", itemsIncluded, maxValue);
        }
    }
}