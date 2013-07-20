namespace _03.ExtractWordsFromFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class WordsExtractor
    {
        /// CAUTION! If you paste the text from the presentation directly into the text file,
        /// it will not work because the encoding somehow does not recognize the "-" character.
        /// Please while pasting delete it and type it again in the file via your keyboard.
        public static void Main()
        {
            Dictionary<string, int> wordOccurances = new Dictionary<string, int>();
            string filePath = "words.txt";
            string line = null;

            using (StreamReader readerText = new StreamReader(filePath))
            {
                line = readerText.ReadLine();
                while (line != null)
                {
                    string[] array = line.Split(new char[] { ' ', ',', '!', '.', '?', ':', ';', '-' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (wordOccurances.ContainsKey(array[i].ToLowerInvariant()))
                        {
                            wordOccurances[array[i].ToLowerInvariant()]++;
                        }
                        else
                        {
                            wordOccurances[array[i].ToLowerInvariant()] = 1;
                        }
                    }

                    line = readerText.ReadLine();
                }
            }

            wordOccurances = wordOccurances.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            foreach (var key in wordOccurances.Keys)
            {
                Console.WriteLine("{0} -> {1}", key, wordOccurances[key]);
            }
        }
    }
}
