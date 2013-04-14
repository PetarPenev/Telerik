using System;
using System.IO;

/* You are given a text. Write a program that changes the text in all regions
 * surrounded by the tags <upcase> and </upcase> to uppercase. The tags cannot be nested. */

// Отново няма зададен стандарт за вход и реших да работя с файлове.

namespace _05.ToUpper
{
    class Program
    {
        static void Main()
        {
            // Задал съм предварително началния и крайния файл, но с откоментиране пътищата може да се въвеждат от конзолата.
            //Console.WriteLine("Please enter the path to the file.");
            //string file=Console.ReadLine();
            string file = "c:\\text.txt";
            //Console.WriteLine("Please enter the path to the destination.");
            //string destination = Console.ReadLine();
            string destination = "c:\\bat.txt";
            bool checkTagOpen=false;
            string line="";
            // Четем всеки ред и преобразуваме текста в съответните тагове (ако ги има), като променливата
            // checkTagOpen служи за това да помним дали имаме незатворен таг от преден ред.
            using (StreamReader reader = new StreamReader(file))
            {
                using (StreamWriter writer = new StreamWriter(destination))
                {
                    line=reader.ReadLine();
                    while (line!=null)
                    {
                        line=ConvertToUpper(line,ref checkTagOpen);
                        writer.WriteLine(line);
                        line=reader.ReadLine();
                    }
                }
            }
        }

        static string ConvertToUpper(string line, ref bool checkTagOpen)
        {
            int indexStart = 0;
            string substring="";
            if (checkTagOpen)
            {
                // Ако имаме отворен таг от преден ред и той не се затваря на настоящия, правим целия ред в главни букви.
                if (line.IndexOf("</upcase>") == -1)
                {
                    line = line.ToUpper();
                    checkTagOpen = true;
                    return line;
                }
                else
                {
                    // В противен случай преобразуваме само частта до затварящия таг и модифицираме стринга line така, че 
                    // първият таг да отпадне.
                    substring = line.Substring(indexStart, line.IndexOf("</upcase>"));
                    substring = substring.ToUpper();
                    indexStart=line.IndexOf("</upcase>") + 9;
                    line = substring + line.Substring(indexStart);
                    checkTagOpen = false;
                }
            }
            // Ако няма срещания на отварящ таг, връщаме реда без повече промени.
            if (line.IndexOf("<upcase>")==-1)
                return line;
            // Иначе докато имаме още отварящи тагове, циклим.
            while (line.IndexOf("<upcase>") != -1)
            {
                // Ако има и той не се затваря, то правим в главни букви всичко след него, модифицираме реда и го връщаме.
                if (line.IndexOf("</upcase>") == -1)
                {
                    substring = line.Substring(line.IndexOf("<upcase>") + 8);
                    substring = substring.ToUpper();
                    line = line.Substring(0, line.IndexOf("<upcase>")) + substring;
                    checkTagOpen=true;
                    return line;
                }
                    // Ако се затваря, то преобразуваме в главни букви всичко между таговете, модифицираме реда и отново
                    // въртим цикъла.
                else
                {
                    substring = line.Substring(line.IndexOf("<upcase>") + 8, line.IndexOf("</upcase>")-line.IndexOf("<upcase>")-8);
                    substring = substring.ToUpper();
                    line = line.Substring(0, line.IndexOf("<upcase>")) + substring + line.Substring(line.IndexOf("</upcase>") + 9);
                }
            }
            return line;
        }


    }
}
