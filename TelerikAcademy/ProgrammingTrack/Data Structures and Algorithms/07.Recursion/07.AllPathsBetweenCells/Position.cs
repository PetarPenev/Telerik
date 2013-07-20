namespace _07.AllPathsBetweenCells
{
    public class Position
    {
        private int firstCoordinate;

        private int secondCoordinate;

        public Position(int x, int y)
        {
            this.firstCoordinate = x;
            this.secondCoordinate = y;
        }

        public override string ToString()
        {
            return "(" + this.firstCoordinate + ", " + this.secondCoordinate + ")";
        }
    }
}