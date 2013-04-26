using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;
using System.Globalization;
using System.Threading;

namespace TestingConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Testing class Path.
                Path path = new Path();
                path.AddPoint(new Point3D(1, 2, 3));
                path.AddPoint(new Point3D(4, 5, 6));
                path.AddPoint(new Point3D(7, 8, 9));
                // Must create the file and fill it according to requirements - each new point on a seperate line
                // with coordinates in brackets - like (3,2,1).
                PathStorage.SetPath(@"c:\result.txt", path);
                Path list = PathStorage.GetPath(@"c:\result.txt");
                foreach (Point3D d in list.Points)
                    Console.WriteLine(d);
                Console.WriteLine();

                // Testing the generic list class.
                MyGenericList<float> genericList = new MyGenericList<float>(3);
                for (int i = 0; i < 5; i++)
                    genericList.AddElement(i + 0.7f);
                Console.WriteLine(genericList.Max());
                genericList.RemoveElement(2);
                Console.WriteLine(genericList);
                Console.WriteLine();

                // Testing the matrix class.
                int[,] arrTest = new int[,] { { -3, 0, 1 }, { -4, 4, 6 } };
                Matrix<int> mat1 = new Matrix<int>(arrTest);
                arrTest = new int[,] { { 2, 5, -1, 1 }, { 3, 0, 4, 6 }, { 7, -4, -3, 8 } };
                Matrix<int> mat2 = new Matrix<int>(arrTest);
                Matrix<int> mat3 = mat1 * mat2;
                Console.WriteLine(mat3);
                Console.WriteLine();

                Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
                Type type = typeof(SampleClassWithAttribute);
                foreach (Library.Version attribute in type.GetCustomAttributes(false))
                {
                    Console.WriteLine("Version is {0}.", attribute.Major);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

