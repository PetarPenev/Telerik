using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.Linq;

namespace _01.MongoData
{
    public class Word 
    {
        [BsonId]
        public ObjectId WordId { get; set; }

        public string WordText { get; set; }

        public string Translation { get; set; }

        public Word(string word, string translation)
        {
            this.WordText = word;
            this.Translation = translation;
        }

        public override string ToString()
        {
            return this.WordText + " : " + this.Translation;
        }
    }

    public static class DictionaryCommands
    {
        public static void AddWord(MongoCollection<Word> collection, string word, string translation)
        {
            Word wordData = new Word(word, translation);
            bool containsWord = collection.AsQueryable<Word>().Any(w => w.WordText == word);
            if (containsWord)
            {
                Console.WriteLine("The word is already added to the dictionary.");
                return;
            }

            collection.Insert(wordData);
            Console.WriteLine("Word added");
        }

        public static void ListAll(MongoCollection<Word> collection)
        {
            foreach (var word in collection.AsQueryable<Word>())
            {
                Console.WriteLine(word);
            }
        }

        public static void FindTranslation(MongoCollection<Word> collection, string word)
        {
            bool containsWord = collection.AsQueryable<Word>().Any(w => w.WordText == word);
            if (!containsWord)
            {
                Console.WriteLine("Word does not exist in the dictionary.");
                return;
            }

            Word wordData = collection.AsQueryable<Word>().First(w => w.WordText == word);
            Console.WriteLine(wordData);
        }

    }

    public class Program
    {
        private static bool isInProgress = true;

        public static void PrintOptions()
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to Mongo Dictionary Implementation!");
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

        public static void Main()
        {
            MongoClient client = new MongoClient("mongodb://localhost/");
            MongoServer server = client.GetServer();

            var dictionaryDatabase = server.GetDatabase("dictionaryData");
            var collection = dictionaryDatabase.GetCollection<Word>("dictionary");

            int answer = 0;
            while (isInProgress)
            {
                PrintOptions();
                bool correctInput = int.TryParse(Console.ReadLine(), out answer);
                if (!correctInput)
                {
                    PrintErrorInputMessage();
                }
                else{
                    switch (answer)
                    {
                        case 1:
                            {
                                Console.WriteLine("Please enter the word:");
                                string word = Console.ReadLine();
                                Console.WriteLine("Please enter the translation:");
                                string translation = Console.ReadLine();
                                DictionaryCommands.AddWord(collection, word, translation);
                                break;
                            }
                        case 2:
                            {
                                DictionaryCommands.ListAll(collection);
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("Please enter the word:");
                                string word = Console.ReadLine();
                                DictionaryCommands.FindTranslation(collection, word);
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