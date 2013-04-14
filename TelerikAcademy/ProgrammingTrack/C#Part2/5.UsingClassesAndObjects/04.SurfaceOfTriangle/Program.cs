using System;

/* Write methods that calculate the surface of a triangle by given:
Side and an altitude to it; Three sides; Two sides and an angle between them. Use System.Math. */

namespace _04.SurfaceOfTriangle
{
    class Program
    {
        static void Main()
        {
            int choice = 0;
            double surface=0;
            bool check = false;
            // Даваме възможност за избор на метод за изчисляване на лицето.
            while (!check)
            {
                Console.WriteLine("Please enter 1 for calculation via side and height, 2 for three sides and 3 for 2 sides and angle.");
                check = int.TryParse(Console.ReadLine(), out choice);
            }
            check=false;
            switch (choice)
            {
                case 1:
                    surface=GetSideHeigth();
                    break;
                case 2:
                    surface=GetThreeSides();
                    break;
                case 3:
                    surface=GetTwoSidesAndAngle();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    check=true;
                    break;
            }
            if (!check)
                Console.WriteLine("The surface is {0}.", surface);
                     

        }

        static double GetSideHeigth()
        {
            int side = 0, height = 0;
            bool internalCheck = false;
            while (!internalCheck)
            {
                Console.WriteLine("Please enter the side");
                internalCheck = int.TryParse(Console.ReadLine(), out side);
            }
            internalCheck = false;
            while (!internalCheck)
            {
                Console.WriteLine("Please enter the height");
                internalCheck = int.TryParse(Console.ReadLine(), out height);
            }
            return (side * height) / 2;
        }

        static double GetThreeSides()
        {
            int firstSide=0, secondSide=0, thirdSide=0;
            bool internalCheck=false;
            while (!internalCheck)
            {
                Console.WriteLine("Please enter the first side.");
                internalCheck=int.TryParse(Console.ReadLine(),out firstSide);
            }
            internalCheck=false;
            while (!internalCheck)
            {
                Console.WriteLine("Please enter the second side.");
                internalCheck=int.TryParse(Console.ReadLine(),out secondSide);
            }
            internalCheck=false;
            while (!internalCheck)
            {
                Console.WriteLine("Please enter the third side.");
                internalCheck=int.TryParse(Console.ReadLine(),out thirdSide);
            }
            double halfPerimeter = (double)(firstSide+secondSide+thirdSide)/2;
            double expression = halfPerimeter * (halfPerimeter - firstSide) * (halfPerimeter - secondSide) * (halfPerimeter - thirdSide);
            return Math.Sqrt(expression);
        }

        static double GetTwoSidesAndAngle()
        {
            int firstSide = 0, secondSide = 0, angle=0;
            bool internalCheck = false;
            while (!internalCheck)
            {
                Console.WriteLine("Please enter the first side.");
                internalCheck = int.TryParse(Console.ReadLine(), out firstSide);
            }
            internalCheck = false;
            while (!internalCheck)
            {
                Console.WriteLine("Please enter the second side.");
                internalCheck = int.TryParse(Console.ReadLine(), out secondSide);
            }
            internalCheck = false;
            while (!internalCheck)
            {
                Console.WriteLine("Please enter the angle in degrees between 0 and 360.");
                internalCheck = int.TryParse(Console.ReadLine(), out angle);
            }
            double radians = angle*0.0174532925;
            return 0.5 * firstSide * secondSide * Math.Sin(radians);

        }
    }
}
