namespace Poker.TestCardAndHand
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;

    [TestClass]
    public class TestHand
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestToStringEmptyList()
        {
            List<ICard> cards = new List<ICard>();
            Hand hand = new Hand(cards);
            hand.ToString();
        }

        [TestMethod]
        public void TestToStringOneCardInHand()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.King, CardSuit.Clubs));
            Hand hand = new Hand(cards);

            string expectedOutput = "King♣";
            Assert.AreEqual(expectedOutput, hand.ToString());
        }

        [TestMethod]
        public void TestToStringFiveCardsInHand()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.King, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Eight, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Four, CardSuit.Clubs));

            Hand hand = new Hand(cards);

            string expectedOutput = "King♣ 2♦ 8♠ Ace♥ 4♣";
            Assert.AreEqual(expectedOutput, hand.ToString());
        }

        [TestMethod]
        public void TestToStringFiveEqualCards()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.King, CardSuit.Clubs));
            cards.Add(new Card(CardFace.King, CardSuit.Clubs));
            cards.Add(new Card(CardFace.King, CardSuit.Clubs));
            cards.Add(new Card(CardFace.King, CardSuit.Clubs));
            cards.Add(new Card(CardFace.King, CardSuit.Clubs));

            Hand hand = new Hand(cards);

            string expectedOutput = "King♣ King♣ King♣ King♣ King♣";
            Assert.AreEqual(expectedOutput, hand.ToString());
        }
    }
}
