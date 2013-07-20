namespace _02.PointInTriangle
{
    using System;

    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Please enter the coordinates of the 3 triangle vertexes and the point to check in that order.");
            Console.WriteLine("Each should be on a seperate row and the coordinates must be separated by spaces.");

            string[] firstVertexInfo = Console.ReadLine().Split(' ');
            Point firstVertex = new Point(double.Parse(firstVertexInfo[0]), double.Parse(firstVertexInfo[1]));

            string[] secondVertexInfo = Console.ReadLine().Split(' ');
            Point secondVertex = new Point(double.Parse(secondVertexInfo[0]), double.Parse(secondVertexInfo[1]));

            string[] thirdVertexInfo = Console.ReadLine().Split(' ');
            Point thirdVertex = new Point(double.Parse(thirdVertexInfo[0]), double.Parse(thirdVertexInfo[1]));

            string[] pointToCheckInfo = Console.ReadLine().Split(' ');
            Point pointToCheck = new Point(double.Parse(pointToCheckInfo[0]), double.Parse(pointToCheckInfo[1]));

            if (!FormTriangle(firstVertex, secondVertex, thirdVertex))
            {
                Console.WriteLine("The points cannot form a triangle.");
                return;
            }

            /// Algorithm: If the point is on one of the lines of the triangle, then it is inside it (we assume that "inside" includes
            /// the sides). Otherwise, if the point P is inside the triangle ABC, then the sum of the areas of the triangles ABP, ACP 
            /// and BCP will not exceed that of the triangle ABC (will not exceed - and not equal - because there may be rounding issues).

            bool isInTriangle = false;
            if (AreOnOneLine(firstVertex, secondVertex, pointToCheck) || AreOnOneLine(firstVertex, thirdVertex, pointToCheck) ||
                AreOnOneLine(secondVertex, thirdVertex, pointToCheck))
            {
                isInTriangle = true;
            }
            else
            {
                double wholeTriangleArea = CalculateArea(firstVertex, secondVertex, thirdVertex);
                double firstCheckArea = CalculateArea(firstVertex, secondVertex, pointToCheck);
                double secondCheckArea = CalculateArea(firstVertex, thirdVertex, pointToCheck);
                double thirdCheckArea = CalculateArea(secondVertex, thirdVertex, pointToCheck);
                double tolerance = 0.01;

                if (Math.Abs(wholeTriangleArea - (firstCheckArea + secondCheckArea + thirdCheckArea)) < tolerance)
                {
                    isInTriangle = true;
                }
            }

            Console.WriteLine("The point is in the triangle: {0}.", isInTriangle);
        }

        private static bool FormTriangle(Point first, Point second, Point third)
        {
            if (AreOnOneLine(first, second, third))
            {
                return false;
            }

            double firstSide = CalculateEuclideanDistance(first, second);
            double secondSide = CalculateEuclideanDistance(first, third);
            double thirdSide = CalculateEuclideanDistance(second, third);

            return firstSide < (secondSide + thirdSide) && secondSide < (firstSide + thirdSide) && thirdSide < (firstSide + secondSide);
        }

        private static bool AreOnOneLine(Point first, Point second, Point third)
        {
            return ((first.FirstCoordinate == second.FirstCoordinate) && (second.FirstCoordinate == third.FirstCoordinate))
                || ((first.SecondCoordinate == second.SecondCoordinate) && (second.SecondCoordinate == third.SecondCoordinate));
        }

        private static double CalculateEuclideanDistance(Point first, Point second)
        {
            return Math.Sqrt((first.FirstCoordinate - second.FirstCoordinate) * (first.FirstCoordinate - second.FirstCoordinate) +
                (first.SecondCoordinate - second.SecondCoordinate) * (first.SecondCoordinate - second.SecondCoordinate));
        }

        private static double CalculateArea(Point first, Point second, Point third)
        {
            double firstSide = CalculateEuclideanDistance(first, second);
            double secondSide = CalculateEuclideanDistance(first, third);
            double thirdSide = CalculateEuclideanDistance(second, third);
            double semiPerimeter = (firstSide + secondSide + thirdSide) / 2;

            return Math.Sqrt(semiPerimeter * (semiPerimeter - firstSide) * (semiPerimeter - secondSide) * (semiPerimeter - thirdSide));
        }
    }
}