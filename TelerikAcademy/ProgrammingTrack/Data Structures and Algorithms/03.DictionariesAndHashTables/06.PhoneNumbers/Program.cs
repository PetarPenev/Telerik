namespace _06.PhoneNumbers
{
    using System;
    using System.IO;
    using System.Text;
    using Wintellect.PowerCollections;

    public class Program
    {
        public static void Main()
        {
            MultiDictionary<string, Tuple<string, string>> phoneBook =
                new MultiDictionary<string, Tuple<string, string>>(true);

            string dataPath = "phones.txt";
            string line = null;

            using (StreamReader readerText = new StreamReader(dataPath))
            {
                line = readerText.ReadLine();
                while (line != null)
                {
                    string[] arrayOfData = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < arrayOfData.Length; i++)
                    {
                        arrayOfData[i] = arrayOfData[i].Trim();
                    }

                    phoneBook[arrayOfData[0]].Add(new Tuple<string, string>(arrayOfData[1], arrayOfData[2]));

                    line = readerText.ReadLine();
                }
            }

            string commandPath = "commands.txt";
            StringBuilder output = new StringBuilder();

            using (StreamReader readerText = new StreamReader(commandPath))
            {
                line = readerText.ReadLine();
                while (line != null)
                {
                    string[] arrayOfData = line.Split(new char[] { '(' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < arrayOfData.Length; i++)
                    {
                        arrayOfData[i] = arrayOfData[i].Trim();
                    }

                    if (arrayOfData[0] != "find")
                    {
                        throw new ArgumentException("Unknown command.");
                    }

                    string[] arguments = arrayOfData[1].Split(new char[] { ',' });
                    for (int i = 0; i < arguments.Length; i++)
                    {
                        arguments[i] = arguments[i].Trim();
                    }

                    arguments[arguments.Length - 1] = arguments[arguments.Length - 1].TrimEnd(new char[] { ')' });

                    if (arguments.Length == 1)
                    {
                        FindByName(arguments[0], phoneBook, output);
                    }
                    else
                    {
                        FindByNameAndTown(arguments[0], arguments[1], phoneBook, output);
                    }

                    line = readerText.ReadLine();
                }
            }

            Console.WriteLine(output);
        }

        public static void FindByName(string name, MultiDictionary<string, Tuple<string, string>> dataDictionary, StringBuilder output)
        {
            var entriesByName = dataDictionary[name];
            foreach (var element in entriesByName)
            {
                output.Append(name);
                output.Append(" -> ");
                output.Append(element.Item1);
                output.Append(" -> ");
                output.AppendLine(element.Item2);
            }
        }

        public static void FindByNameAndTown(string name, string town, MultiDictionary<string, Tuple<string, string>> dataDictionary, 
            StringBuilder output)
        {
            var entriesByName = dataDictionary[name];
            if (entriesByName == null)
            {
                return;
            }

            foreach (var element in entriesByName)
            {
                if (element.Item1 == town)
                {
                    output.Append(name);
                    output.Append(" -> ");
                    output.Append(element.Item1);
                    output.Append(" -> ");
                    output.AppendLine(element.Item2);
                }
            }
        }
    }
}
