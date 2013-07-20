namespace Poker.TestChecker
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestCheckerIsHighCard
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInvalidHand()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.King, CardSuit.Spades));
            cards.Add(new Card(CardFace.King, CardSuit.Hearts));
            cards.Add(new Card(CardFace.King, CardSuit.Clubs));
            cards.Add(new Card(CardFace.King, CardSuit.Clubs));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsHighCard(hand));
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

            Assert.IsTrue(checker.IsHighCard(hand));
        }

        [TestMethod]
        public void TestOnePair()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Five, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Eight, CardSuit.Spades));
            cards.Add(new Card(CardFace.Three, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Five, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Queen, CardSuit.Spades));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsHighCard(hand));
        }

        [TestMethod]
        public void TestTwoPairs()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Five, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Eight, CardSuit.Spades));
            cards.Add(new Card(CardFace.Three, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Five, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Eight, CardSuit.Hearts));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsHighCard(hand));
        }

        [TestMethod]
        public void TestThreeOfAKind()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Five, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Five, CardSuit.Spades));
            cards.Add(new Card(CardFace.Three, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Five, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Queen, CardSuit.Spades));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsHighCard(hand));
        }

        [TestMethod]
        public void TestFourOfAKind()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Five, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Five, CardSuit.Spades));
            cards.Add(new Card(CardFace.Three, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Five, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsHighCard(hand));
        }

        [TestMethod]
        public void TestFullHouse()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.King, CardSuit.Spades));
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Queen, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsHighCard(hand));
        }

        [TestMethod]
        public void TestFlush()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Five, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Eight, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Three, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Jack, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsHighCard(hand));
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

            Assert.IsFalse(checker.IsHighCard(hand));
        }

        [TestMethod]
        public void TestStraight()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Five, CardSuit.Spades));
            cards.Add(new Card(CardFace.Six, CardSuit.Spades));
            cards.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Eight, CardSuit.Spades));
            cards.Add(new Card(CardFace.Nine, CardSuit.Spades));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsHighCard(hand));
        }
    }
}
