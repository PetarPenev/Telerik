using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.ConvertToPronounciation
{
    class Program
    {
        static void Main()
        {
            int[] digits = new int[3];
            string[,] names = 
            {
            {"one","two","three","four","five","six","seven","eight","nine"},
            {"eleven","twelve","thirteen","fourteen","fifteen","sixteen","seventeen","eighteen","nineteen"},
            {"ten","twenty","thirty","fourty","fifty","sixty","seventy","eighty","ninety"}
                     };
            Console.WriteLine("Please enter a number between 0 and 999.");
            string number = Console.ReadLine();
            int num;
            string output = "";
            bool check = false;
            bool check2 = false;
            bool check3 = false;
            bool check4 = false;
            if (int.TryParse(number, out num) == false)
            {
                Console.WriteLine("Not a number or too large number.");
                check = true;
            }
            else
            {
                if ((num < 0) || (num > 999))
                {
                    Console.WriteLine("Number not in specified range");
                    check = true;
                }
                else
                {
                    //number = num.ToString();
                    if (num/100>0)
                    {
                        output=output+names[0,(num/100-1)]+" hundred";
                        check2=true;
                    }
                    num=num-(num/100)*100;
                    if (num/10>1)
                    {
                        if (check2 == true)
                        {
                            output += " ";
                        }
                        output=output+names[2,(num/10-1)];
                        check3=true;
                    }
                    else if (num/10==1)
                    {
                        if (check2 == true)
                        {
                            output += " and ";
                        }
                        output+=names[1,(num%10-1)];
                        check3 = true;
                        check4 = true;
                    }
                    num=num-(num/10)*10;
                    if ((num!=0) && (check2==true) && (check3==false))
                    {
                        output+=" and ";
                        output+=names[0,num-1];
                    }
                    else if ((num!=0) && (check2==false) && (check3==false))
                    {
                        output+=names[0,num-1];
                    }
                    else if ((check2 == true) && (check3 == true) && (check4==false))
                    {
                        output = output + " " + names[0, num - 1];
                    }
                    else if ((check2==false) && (check3==true) && (check4==false))
                    {
                        output = output + " " + names[0, num - 1];
                    }
                    else if ((num == 0) && (output == ""))
                    {
                        output = "zero";
                    }
            }
            if (check == false)
            {
                output=char.ToUpper(output[0])+output.Substring(1);
                Console.WriteLine(output);
            }
            }
        }
    }
}
