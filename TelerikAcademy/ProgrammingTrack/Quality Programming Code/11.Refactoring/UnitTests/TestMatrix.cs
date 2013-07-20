namespace TestMatrix
{
    using System;
    using System.Text;
    using LinearAlgebra;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    // We are testing the methods (with coverage above 90%) only through the public interface.
    // On why you should not unit test private methods - see here:
    // http://www.peterprovost.org/blog/2012/05/31/my-take-on-unit-testing-private-methods
    [TestClass]
    public class TestMatrix
    {
        [TestMethod]
        public void TestConstructorWithValidInput()
        {
            Matrix matrix = new Matrix(5);
            Assert.AreEqual(0, matrix.CurrentPosition.Row);
            Assert.AreEqual(0, matrix.CurrentPosition.Column);

            StringBuilder representation = new StringBuilder();
            for (int i = 0; i < 5; i++)
            {
                representation.AppendLine(string.Format("{0,4} {0,4} {0,4} {0,4} {0,4}", 0));
            }

            Assert.AreEqual(representation.ToString().TrimEnd('\r', '\n'), matrix.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructorWithInvalidInput()
        {
            Matrix matrix = new Matrix(-2);
        }

        [TestMethod]
        public void TestTraversalOfMatrixOfSizeOne()
        {
            Matrix matrix = new Matrix(1);
            Assert.AreEqual("   0", matrix.ToString());
            matrix.Traverse();
            Assert.AreEqual("   1", matrix.ToString());
        }

        [TestMethod]
        public void TestTraversalOfMatrixOfSizeThree()
        {
            Matrix matrix = new Matrix(3);
            StringBuilder representation = new StringBuilder();
            for (int i = 0; i < 3; i++)
            {
                representation.AppendLine(string.Format("{0,4} {0,4} {0,4}", 0));
            }

            Assert.AreEqual(representation.ToString().TrimEnd('\r', '\n'), matrix.ToString());
            matrix.Traverse();
            StringBuilder newRepresentation = new StringBuilder();
            newRepresentation.AppendLine(string.Format("{0,4} {1,4} {2,4}", 1, 7, 8));
            newRepresentation.AppendLine(string.Format("{0,4} {1,4} {2,4}", 6, 2, 9));
            newRepresentation.AppendLine(string.Format("{0,4} {1,4} {2,4}", 5, 4, 3));
            Assert.AreEqual(newRepresentation.ToString().TrimEnd('\r', '\n'), matrix.ToString());
        }

        [TestMethod]
        public void TestTraversalOfMatrixOfSizeSix()
        {
            Matrix matrix = new Matrix(6);
            StringBuilder representation = new StringBuilder();
            for (int i = 0; i < 6; i++)
            {
                representation.AppendLine(string.Format("{0,4} {0,4} {0,4} {0,4} {0,4} {0,4}", 0));
            }

            Assert.AreEqual(representation.ToString().TrimEnd('\r', '\n'), matrix.ToString());
            matrix.Traverse();
            StringBuilder newRepresentation = new StringBuilder();
            newRepresentation.AppendLine(string.Format("{0,4} {1,4} {2,4} {3,4} {4,4} {5,4}", 1, 16, 17, 18, 19, 20));
            newRepresentation.AppendLine(string.Format("{0,4} {1,4} {2,4} {3,4} {4,4} {5,4}", 15, 2, 27, 28, 29, 21));
            newRepresentation.AppendLine(string.Format("{0,4} {1,4} {2,4} {3,4} {4,4} {5,4}", 14, 31, 3, 26, 30, 22));
            newRepresentation.AppendLine(string.Format("{0,4} {1,4} {2,4} {3,4} {4,4} {5,4}", 13, 36, 32, 4, 25, 23));
            newRepresentation.AppendLine(string.Format("{0,4} {1,4} {2,4} {3,4} {4,4} {5,4}", 12, 35, 34, 33, 5, 24));
            newRepresentation.AppendLine(string.Format("{0,4} {1,4} {2,4} {3,4} {4,4} {5,4}", 11, 10, 9, 8, 7, 6));
            Assert.AreEqual(newRepresentation.ToString().TrimEnd('\r', '\n'), matrix.ToString());
        }
    }
}
