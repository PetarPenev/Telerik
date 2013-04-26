using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Matrix<T> where T:struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        // 8 Task
        private T[,] arr;

        public T[,] Arr
        {
            get { return arr; }
            private set { arr = value; }
        }

        public Matrix(int horizontal, int vertical)
        {
            if ((horizontal <= 0) || (vertical <= 0))
                throw new ArgumentException("The dimensions of the matrix must be positive integer numbers.");
            this.Arr = new T[horizontal, vertical];
        }

        public Matrix(T[,] matrix)
        {
            if ((matrix == null) || (matrix.GetLength(0) <= 0) || (matrix.GetLength(1) <= 1))
                throw new ArgumentException("Must pass a valid two-dimensional array to the matrix constructor.");
            this.Arr = matrix;
        }

        // 9 Task
        public T this[int i, int j]
        {
            get
            {
                if ((i < 0) || (j < 0) || (i >= this.Arr.GetLength(0)) || (j >= this.Arr.GetLength(1)))
                    throw new ArgumentOutOfRangeException("Index out of range.");
                return this.Arr[i, j];
            }

            set
            {
                if ((i < 0) || (j < 0) || (i >= this.Arr.GetLength(0)) || (j >= this.Arr.GetLength(1)))
                    throw new ArgumentOutOfRangeException("Index out of range.");
                this.Arr[i, j] = value;
            }
        }

        // 10 Task
        public static Matrix<T> operator +(Matrix<T> first, Matrix<T> second)
        {
            if ((first == null) || (second == null))
                throw new OperationCanceledException("Incorrectly initialized matrices.");
            if ((first.Arr.GetLength(0) != second.Arr.GetLength(0)) || (first.Arr.GetLength(1) != second.Arr.GetLength(1)))
                throw new InvalidOperationException("The required operation (addition) cannot be performed due to size differences.");
            Matrix<T> tempMatrix = new Matrix<T>(first.Arr.GetLength(0), first.Arr.GetLength(1));
            for (int i = 0; i < first.Arr.GetLength(0); i++)
                for (int j = 0; j < first.Arr.GetLength(1);j++ )
                    tempMatrix[i, j] = (dynamic)first[i, j] + second[i, j];
            return tempMatrix;
        }

        public static Matrix<T> operator -(Matrix<T> first, Matrix<T> second)
        {
            if ((first == null) || (second == null))
                throw new OperationCanceledException("Incorrectly initialized matrices.");
            if ((first.Arr.GetLength(0) != second.Arr.GetLength(0)) || (first.Arr.GetLength(1) != second.Arr.GetLength(1)))
                throw new InvalidOperationException("The required operation (substraction) cannot be performed due to size differences.");
            Matrix<T> tempMatrix = new Matrix<T>(first.Arr.GetLength(0), first.Arr.GetLength(1));
            for (int i = 0; i < first.Arr.GetLength(0); i++)
                for (int j = 0; j < first.Arr.GetLength(1);j++ )
                    tempMatrix[i, j] = (dynamic)first[i, j] - second[i, j];
            return tempMatrix;
        }

        public static Matrix<T> operator *(Matrix<T> first, Matrix<T> second)
        {
            if ((first == null) || (second == null))
                throw new OperationCanceledException("Incorrectly initialized matrices.");
            if ((first.Arr.GetLength(1)!=second.Arr.GetLength(0)))
                throw new InvalidOperationException("The required operation (multiplication) cannot be performed due to size differences.");
            Matrix<T> tempMatrix = new Matrix<T>(first.Arr.GetLength(0),second.Arr.GetLength(1));
            for (int i=0;i<first.Arr.GetLength(0);i++)
                for (int j = 0; j < second.Arr.GetLength(1); j++)
                {
                    for (int k = 0; k < first.Arr.GetLength(1); k++)
                        tempMatrix[i, j] = tempMatrix[i, j] + (dynamic)first.Arr[i, k] * second.Arr[k, j];
                }
            return tempMatrix;
        }

        public static bool BoolOperator(Matrix<T> mat)
        {
            if (mat == null)
                throw new OperationCanceledException("Incorrectly initialized matrix.");
            for (int i = 0; i < mat.Arr.GetLength(0); i++)
                for (int j = 0; j < mat.Arr.GetLength(1); j++)
                    if (mat[i, j] != (dynamic)0)
                        return true;
            return false;
        }

        public override string ToString()
        {
            string[] strArr = new string[this.Arr.GetLength(0)];
            for (int i=0;i<this.Arr.GetLength(0);i++)
            {
                StringBuilder row = new StringBuilder();
                for (int j = 0; j < this.Arr.GetLength(1);j++ )
                    row.Append(this.Arr[i, j].ToString() + " ");
                row.Remove(row.Length-1,1);
                strArr[i]=row.ToString();
            }
            return String.Join(Environment.NewLine,strArr);
        }
    }
}
