using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.RedisData
{
    public static class DictionaryCommands
    {
        public const string wordHashStructure = "words";

        public static void AddWord(RedisClient client, string word, string translation)
        {
            if (client.HExists(wordHashStructure, word.ToAsciiCharArray()) != 0)
            {
                Console.WriteLine("The word is already added to the dictionary.");
                return;
            }

            client.HSetNX(wordHashStructure, word.ToAsciiCharArray(), translation.ToAsciiCharArray());
            Console.WriteLine("Word added");
        }

        public static void ListAll(RedisClient client)
        {
            var keys = client.HKeys(wordHashStructure);
            var stringifiedKeys = new List<string>();
            foreach (var key in keys)
            {
                stringifiedKeys.Add(Extensions.StringFromByteArray(key));
            }

            foreach (var key in stringifiedKeys)
            {
                Console.WriteLine(key + " : " + Extensions.StringFromByteArray(client.HGet(wordHashStructure, key.ToAsciiCharArray())));
            }
        }

        public static void FindTranslation(RedisClient client, string word)
        {
            if (client.HExists(wordHashStructure, word.ToAsciiCharArray()) == 0)
            {
                Console.WriteLine("Word does not exist in the dictionary.");
                return;
            }

            var translation = Extensions.StringFromByteArray(client.HGet(wordHashStructure, word.ToAsciiCharArray()));
            Console.WriteLine(word + ":" + translation);
        }

    }

    class Program
    {
        private static bool isInProgress = true;

        public static void PrintOptions()
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to Redis Dictionary Implementation!");
            Console.WriteLine("Please choose your options:");
            Console.WriteLine("1.Add a word.");
            Console.WriteLine("2.List all words.");
            Console.WriteLine("3.Find word translation.");
            Console.WriteLine("4.Exit.");
            Console.WriteLine();
        }

        public static void PrintErrorInputMessage()
        {
            Console.WriteLine("Incorrectly specified option.");
        }

        static void Main()
        {
            using (RedisClient client = new RedisClient("localhost", 6379))
            {
                int answer = 0;
                while (isInProgress)
                {
                    PrintOptions();
                    bool correctInput = int.TryParse(Console.ReadLine(), out answer);
                    if (!correctInput)
                    {
                        PrintErrorInputMessage();
                    }
                    else
                    {
                        switch (answer)
                        {
                            case 1:
                                {
                                    Console.WriteLine("Please enter the word:");
                                    string word = Console.ReadLine();
                                    Console.WriteLine("Please enter the translation:");
                                    string translation = Console.ReadLine();
                                    DictionaryCommands.AddWord(client, word, translation);
                                    break;
                                }
                            case 2:
                                {
                                    DictionaryCommands.ListAll(client);
                                    break;
                                }
                            case 3:
                                {
                                    Console.WriteLine("Please enter the word:");
                                    string word = Console.ReadLine();
                                    DictionaryCommands.FindTranslation(client, word);
                                    break;
                                }
                            case 4:
                                {
                                    isInProgress = false;
                                    Console.WriteLine("Goodbye");
                                    break;
                                }
                            default:
                                {
                                    PrintErrorInputMessage();
                                    break;
                                }
                        }
                    }
                }
            }
        }
    }
}