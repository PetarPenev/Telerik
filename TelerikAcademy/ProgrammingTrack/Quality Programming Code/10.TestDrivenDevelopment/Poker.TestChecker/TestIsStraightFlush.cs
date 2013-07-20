namespace Poker.TestChecker
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestCheckerIsStraightFlush
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInvalidHand()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Five, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Five, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Eight, CardSuit.Spades));
            cards.Add(new Card(CardFace.Three, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsStraightFlush(hand));
        }

        [TestMethod]
        public void TestHighCard()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Five, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Eight, CardSuit.Spades));
            cards.Add(new Card(CardFace.Three, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Queen, CardSuit.Spades));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsStraightFlush(hand));
        }

        [TestMethod]
        public void TestNormalFlush()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Five, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Eight, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Three, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Jack, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsStraightFlush(hand));
        }

        [TestMethod]
        public void TestOneShortOfStraightFlush()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Five, CardSuit.Spades));
            cards.Add(new Card(CardFace.Six, CardSuit.Spades));
            cards.Add(new Card(CardFace.Seven, CardSuit.Spades));
            cards.Add(new Card(CardFace.Eight, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ten, CardSuit.Spades));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsStraightFlush(hand));
        }

        [TestMethod]
        public void TestStraightFlush()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Five, CardSuit.Spades));
            cards.Add(new Card(CardFace.Six, CardSuit.Spades));
            cards.Add(new Card(CardFace.Seven, CardSuit.Spades));
            cards.Add(new Card(CardFace.Eight, CardSuit.Spades));
            cards.Add(new Card(CardFace.Nine, CardSuit.Spades));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsStraightFlush(hand));
        }
    }
}
