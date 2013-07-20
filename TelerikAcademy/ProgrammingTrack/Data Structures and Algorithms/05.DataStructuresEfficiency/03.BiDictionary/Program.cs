namespace _03.BiDictionary
{
    using System;

    public class Program
    {
        public static void Main()
        {
            BiDictionary<string, string, int> dict = new BiDictionary<string, string, int>();
            dict.AddElement("Pesho", "Vasilev", 23);
            dict.AddElement("Pesho", "Hristov", 25);
            dict.AddElement("Ivan", "Hristov", 27);
            dict.AddElement("Stoyan", "Hristov", 20);
            var valuesOfAge = dict.FindByKey2("Hristov");
            foreach (var ageValue in valuesOfAge)
            {
                Console.WriteLine(ageValue);
            }
        }
    }
}
