using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Carpets
{
    class Program
    {
        static void Main()
        {
            int n,numPoints,numHelpStrings,help;
            n = int.Parse(Console.ReadLine());
            string[] mass = new string[n];
            numPoints=n/2-1;
            numHelpStrings=0;
            for (int i = 0; i < n / 2; i++)
            {

                //mass[i] = new string('.', numPoints) + @"/" + Convert.ToString(Enumerable.Repeat(@" /", numHelpStrings)) + Convert.ToString(Enumerable.Repeat(@" /", i % 2)) + Convert.ToString(Enumerable.Repeat(@"\ ", numHelpStrings)) + @"\" + new string('.', numPoints);
                mass[i] = new string('.', numPoints) + @"/";
                for (int l = 0; l < numHelpStrings; l++)
                    mass[i] += @" /";
                if ((i != 0) && (i % 2 == 1))
                    mass[i] += "  ";
                for (int l = 0; l < numHelpStrings; l++)
                    mass[i] += @"\ ";
                mass[i] += @"\" + new string('.', numPoints);

                numPoints--;
                if ((i != 0) && (i % 2 == 1))
                    numHelpStrings++;
                //Console.WriteLine(mass[i]);
            }
            numPoints = 0;
            if ((n / 2) % 2 == 0)
                help = 1;
            else help = 0;
            if ((n / 2) % 2 == 0)
                numHelpStrings = 1+(n-8) / 4;
            else
                numHelpStrings = 1+(n-6) / 4;

            for (int i = 0; i < n / 2; i++)
            {

                //mass[i] = new string('.', numPoints) + @"/" + Convert.ToString(Enumerable.Repeat(@" /", numHelpStrings)) + Convert.ToString(Enumerable.Repeat(@" /", i % 2)) + Convert.ToString(Enumerable.Repeat(@"\ ", numHelpStrings)) + @"\" + new string('.', numPoints);
                mass[i+n/2] = new string('.', numPoints);
                mass[i + n / 2] += @"\";
                for (int l = 0; l < numHelpStrings; l++)
                    mass[i+n/2] += @" \";
                if (i % 2 != help)
                    mass[i+n/2] += "  ";
                for (int l = 0; l < numHelpStrings; l++)
                    mass[i+n/2] += @"/ ";
                mass[i+n/2] += @"/" + new string('.', numPoints);

                numPoints++;
                if (i % 2 == help)
                    numHelpStrings--;
                //Console.WriteLine(mass[i+n/2]);

            }
            for (int i=0;i<n;i++)
                Console.WriteLine(mass[i]);

        }
    }
}
