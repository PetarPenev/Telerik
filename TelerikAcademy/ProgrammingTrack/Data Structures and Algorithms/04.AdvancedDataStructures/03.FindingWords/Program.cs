namespace _03.FindingWords
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    
    public class Program
    {
        public static void Main()
        {
            // Please test with your own files - if I include a 100 MB text file
            // in the archive, it will exceeed the limit for the Telerik Student
            // System which is 16 megabytes.
            string textPath = "C:\\largeText.txt";
            string wordSetPath = "C:\\wordSet.txt";

            Trie trie = new Trie();
            Dictionary<string, int> occurances = new Dictionary<string, int>();

            // Here we are using a somehow different approach. We will build a trie with the words that we will be searching for 
            // and put them in a dictionary with key the word and value the number of occurances (starting at 0). Then, for each
            // word in the text we will look it up in the trie and, if it is there, we will increase the occurances of the particular
            // word with 1. In most situations this will perform better as building the trie is faster. Whether searching is faster
            // depends entirely on how "large" is the intersection between the words in the text and the words we are searching for
            // but generally the performance differences ought to not be very dramatic.
            using (StreamReader reader = new StreamReader(wordSetPath))
            {
                var words = reader.ReadToEnd().Split(new char[] { '.', ',', ' ', '!', '?', ';', ':', '(', ')', '[', ']', '{', '}' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < words.Length; i++)
                {
                    trie.AddWord(words[i]);
                    occurances.Add(words[i], 0);
                }
            }

            using (StreamReader reader = new StreamReader(textPath))
            {
                var words = reader.ReadToEnd().Split(new char[] { '.', ',', ' ', '!', '?', ';', ':', '(', ')', '[', ']', '{', '}' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < words.Length; i++)
                {
                    if (trie.ContainWord(words[i]))
                    {
                        occurances[words[i]] += 1;
                    }
                }
            }

            foreach (var key in occurances.Keys)
            {
                Console.WriteLine("{0} -> {1} time(s)", key, occurances[key]);
            }
        }
    }
}
