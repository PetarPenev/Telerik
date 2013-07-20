namespace LinearAlgebra
{
    using System;

    public class Position
    {
        private int row;

        private int column;

        public Position(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        public int Row
        {
            get
            {
                return this.row;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Value should be 0 or positive.");
                }

                this.row = value;
            }
        }

        public int Column
        {
            get
            {
                return this.column;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Value should be 0 or positive.");
                }

                this.column = value;
            }
        }
    }
}
