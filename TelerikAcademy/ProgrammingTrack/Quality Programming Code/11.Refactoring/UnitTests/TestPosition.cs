namespace TestMatrix
{
    using System;
    using LinearAlgebra;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestPosition
    {
        [TestMethod]
        public void TestConstructorValidArguments()
        {
            Position position = new Position(1, 4);
            Assert.AreEqual(1, position.Row);
            Assert.AreEqual(4, position.Column);
        }

        [TestMethod]
        public void TestConstructorValidArgumentsBothZero()
        {
            Position position = new Position(0, 0);
            Assert.AreEqual(0, position.Row);
            Assert.AreEqual(0, position.Column);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestConstructorInvalidRow()
        {
            Position position = new Position(-1, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestConstructorInvalidColumn()
        {
            Position position = new Position(0, -34);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestConstructorInvalidRowAndColumn()
        {
            Position position = new Position(-16, -34);
        }
    }
}
