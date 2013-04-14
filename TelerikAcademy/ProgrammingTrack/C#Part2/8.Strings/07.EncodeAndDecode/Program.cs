using System;
using System.Text;


namespace _07.EncodeAndDecode
{
    class Program
    {
        static void Main()
        {
            // Четем стринга и шифъра.
            Console.WriteLine("Please enter the string to be encoded/decoded");
            StringBuilder text = new StringBuilder(Console.ReadLine());
            Console.WriteLine("Please enter the cypher.");
            StringBuilder cypher = new StringBuilder(Console.ReadLine());
            StringBuilder result = new StringBuilder();
            // Тъй като процесът на криптиране и декриптиране е еднакъв, то ни е необходим само 1 метод за това.
            // Първо криптираме, извеждаме резултата, после декриптираме и получаваме оригиналният текст.
            // Забележете, че е възможно в изведения закодиран стринг да се показват системни символи и/или символи от
            // ASCII таблицата, които не може да се визуализират, тъй като в алгоритъма за криптиране/декриптиране от задачата
            // по никакъв начин не е предотвратен подобен резултат.
            result = EncryptOrDecrypt(text, cypher);
            Console.WriteLine(result);
            result = EncryptOrDecrypt(result, cypher);
            Console.WriteLine(result);
        }

        static StringBuilder EncryptOrDecrypt(StringBuilder text, StringBuilder cypher)
        {
            // Правим си нов стринг билдър и го записваме по дадения алгоритъм.
            StringBuilder result = new StringBuilder();
            int cypherIndex=0;
            for (int i = 0; i < text.Length; i++)
            {
                result.Append(Convert.ToChar(text[i] ^ cypher[cypherIndex % cypher.Length]));
                cypherIndex++;
            }
            return result;
        }

        
    }
}
