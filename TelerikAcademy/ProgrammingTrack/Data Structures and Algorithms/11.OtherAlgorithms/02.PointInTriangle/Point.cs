namespace _02.PointInTriangle
{
    public class Point
    {
        public Point(double x, double y)
        {
            this.FirstCoordinate = x;
            this.SecondCoordinate = y;
        }

        public double FirstCoordinate { get; private set; }

        public double SecondCoordinate { get; private set; }
    }
}