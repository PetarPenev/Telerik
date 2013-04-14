using System;

/* A dictionary is stored as a sequence of text lines containing words and their explanations. 
 * Write a program that enters a word and translates it by using the dictionary. */

namespace _14.Dictionary
{
    class Program
    {
        static void Main()
        {
            // Приемам, че речникът е зададен като стринг масив - в условието няма ограничение.
            string[] dictionary = {
                                    ".NET – platform for applications from Microsoft",
                                    "CLR – managed execution environment for .NET",
                                    "namespace – hierarchical organization of classes"
                                  };
            // Чета думата/
            Console.WriteLine("Please enter the word");
            string word = Console.ReadLine(), definition="", intermediate="";
            // Цикля по елементите на масива.
            foreach (string c in dictionary)
            {
                // Ако даденият елемент започва с думата и тя не е част от сложна дума (например думата net и речника с 
                // дума netbook), то вземам първият подстринг след дефиницията, който започва с дума, а не с пунктуация
                // ( в условието няма ясно указание как са разделени думите, макар да се подразбира дума - дефиниция. 
                // Затова правя решението да работи за този + някои други случаи.
                if ((c.IndexOf(word) == 0) && (!Char.IsLetterOrDigit(c[word.Length])))
                {
                    intermediate = c.Substring(word.Length);
                    int counter = 0;
                    while (true)
                    {
                        if (char.IsLetterOrDigit(intermediate[counter]))
                        {
                            definition = intermediate.Substring(counter);
                            break;
                        }
                        counter++;
                        if (counter > intermediate.Length)
                            break;
                    }
                    break;
                }
            }
            // Извеждаме дефиницията, ако сме намерили думата.
            if (definition!=String.Empty)
                Console.WriteLine(definition);
            else
                Console.WriteLine("Word not in dictionary.");

        }
    }
}
