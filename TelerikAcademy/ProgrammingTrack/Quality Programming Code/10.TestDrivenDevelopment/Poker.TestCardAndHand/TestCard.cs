namespace Poker.TestCardAndHand
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;

    [TestClass]
    public class TestCard
    {
        [TestMethod]
        public void TestToStringSevenHearts()
        {
            Card card = new Card(CardFace.Seven, CardSuit.Hearts);
            string expectedOutput = "7♥";
            Assert.AreEqual(card.ToString(), expectedOutput);
        }

        [TestMethod]
        public void TestToStringTenClubs()
        {
            Card card = new Card(CardFace.Ten, CardSuit.Clubs);
            string expectedOutput = "10♣";
            Assert.AreEqual(card.ToString(), expectedOutput);
        }

        [TestMethod]
        public void TestToStringJackDiamonds()
        {
            Card card = new Card(CardFace.Jack, CardSuit.Diamonds);
            string expectedOutput = "Jack♦";
            Assert.AreEqual(card.ToString(), expectedOutput);
        }

        [TestMethod]
        public void TestToStringAceHearts()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Hearts);
            string expectedOutput = "Ace♥";
            Assert.AreEqual(card.ToString(), expectedOutput);
        }

        [TestMethod]
        public void EqualsNullObject()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Hearts);
            Assert.IsFalse(card.Equals(null));
        }

        [TestMethod]
        public void EqualsOtherTypeObject()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Hearts);
            Assert.IsFalse(card.Equals("Telerik"));
        }

        [TestMethod]
        public void EqualsEqualCard()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Hearts);
            Assert.IsTrue(card.Equals(new Card(CardFace.Ace, CardSuit.Hearts)));
        }

        [TestMethod]
        public void EqualsSelf()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Hearts);
            Assert.IsTrue(card.Equals(card));
        }

        [TestMethod]
        public void EqualsSameFaceDifferentSuit()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Hearts);
            Assert.IsFalse(card.Equals(new Card(CardFace.Ace, CardSuit.Diamonds)));
        }

        [TestMethod]
        public void EqualsSameSuitDifferentFace()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Hearts);
            Assert.IsFalse(card.Equals(new Card(CardFace.Three, CardSuit.Hearts)));
        }
    }
}