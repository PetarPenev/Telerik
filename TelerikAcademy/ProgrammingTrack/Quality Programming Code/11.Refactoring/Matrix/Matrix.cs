namespace LinearAlgebra
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Matrix
    {
        private int currentNumber;

        private int rows;

        private Position currentPosition;

        private int[,] matrix;

        public Matrix(int number)
        {
            this.Rows = number;
            this.matrix = new int[this.Rows, this.Rows];
            this.currentPosition = new Position(0, 0);
            this.currentNumber = 1;
        }

        public int Rows
        {
            get
            {
                return this.rows;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Value of the rows of the matrix should be positive.");
                }

                this.rows = value;
            }
        }

        public Position CurrentPosition
        {
            get { return this.currentPosition; }
            set { this.currentPosition = value; }
        }

        public override string ToString()
        {
            StringBuilder representation = new StringBuilder();
            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Rows; col++)
                {
                    representation.Append(string.Format("{0, 4} ", this.matrix[row, col]));
                }

                representation.Remove(representation.Length - 1, 1);
                representation.Append(Environment.NewLine);
            }

            return representation.ToString().TrimEnd('\r', '\n');
        }

        public void Traverse()
        {
            while (!this.CheckIfFilled())
            {
                Position startingPosition = this.GetFreePosition();
                this.CurrentPosition = startingPosition;

                int rowMove = 1;
                int columnMove = 1;

                while (this.MoveAvailable())
                {
                    this.matrix[this.CurrentPosition.Row, this.CurrentPosition.Column] = this.currentNumber;
                    this.currentNumber++;
                    if (!this.MoveAvailable())
                    {
                        break;
                    }

                    if ((this.CurrentPosition.Row + rowMove >= this.Rows) || (this.CurrentPosition.Row + rowMove < 0) || (this.CurrentPosition.Column + columnMove >= this.Rows) || (this.CurrentPosition.Column + columnMove < 0) || (this.matrix[this.CurrentPosition.Row + rowMove, this.CurrentPosition.Column + columnMove] != 0))
                    {
                        while ((this.CurrentPosition.Row + rowMove >= this.Rows) || (this.CurrentPosition.Row + rowMove < 0) || (this.CurrentPosition.Column + columnMove >= this.Rows) || (this.CurrentPosition.Column + columnMove < 0) || (this.matrix[this.CurrentPosition.Row + rowMove, this.CurrentPosition.Column + columnMove] != 0))
                        {
                            this.MovePosition(ref rowMove, ref columnMove);
                        }
                    }

                    this.CurrentPosition.Row += rowMove;
                    this.CurrentPosition.Column += columnMove;
                }

                // This following line needs to be both in the inner and the outher cycle for the code to work.
                // Without it in the outer cycle, the setting of the last position either will never happen (if not present
                // at all) or will happen with a number that is +1 to the correct number (if put in the wrong place).
                if (!this.CheckIfFilled())
                {
                    this.matrix[this.CurrentPosition.Row, this.CurrentPosition.Column] = this.currentNumber;
                    this.currentNumber++;
                }
            }
        }

        private void MovePosition(ref int dx, ref int dy)
        {
            int[] directionsInRows = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionsInColumns = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int directionNumber = 0;
            for (int count = 0; count < 8; count++)
            {
                if ((directionsInRows[count] == dx) && (directionsInColumns[count] == dy))
                {
                    directionNumber = count;
                    break;
                }
            }

            if (directionNumber == 7)
            {
                dx = directionsInRows[0];
                dy = directionsInColumns[0];
                return;
            }

            dx = directionsInRows[directionNumber + 1];
            dy = directionsInColumns[directionNumber + 1];
        }

        private bool MoveAvailable()
        {
            int[] directionsInRows = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionsInColumns = { 1, 0, -1, -1, -1, 0, 1, 1 };
            for (int i = 0; i < 8; i++)
            {
                if ((this.CurrentPosition.Row + directionsInRows[i] >= this.matrix.GetLength(0)) ||
                    (this.CurrentPosition.Row + directionsInRows[i] < 0))
                {
                    directionsInRows[i] = 0;
                }

                if ((this.CurrentPosition.Column + directionsInColumns[i] >= this.matrix.GetLength(0)) ||
                    (this.CurrentPosition.Column + directionsInColumns[i] < 0))
                {
                    directionsInColumns[i] = 0;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if (this.matrix[this.CurrentPosition.Row + directionsInRows[i], this.CurrentPosition.Column + directionsInColumns[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckIfFilled()
        {
            bool isFilled = true;
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Rows; j++)
                {
                    if (this.matrix[i, j] == 0)
                    {
                        isFilled = false;
                        break;
                    }
                }
            }

            return isFilled;
        }

        private Position GetFreePosition()
        {
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Rows; j++)
                {
                    if (this.matrix[i, j] == 0)
                    {
                        return new Position(i, j);
                    }
                }
            }

            throw new ArgumentException("No free position in the matrix.");
        }
    }
}
