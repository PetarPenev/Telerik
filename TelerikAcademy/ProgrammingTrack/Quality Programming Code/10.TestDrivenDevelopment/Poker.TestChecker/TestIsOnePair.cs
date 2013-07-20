namespace Poker.TestChecker
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestCheckerIsOnePair
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

            Assert.IsFalse(checker.IsOnePair(hand));
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

            Assert.IsFalse(checker.IsOnePair(hand));
        }

        [TestMethod]
        public void TestOnePair()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Five, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Eight, CardSuit.Spades));
            cards.Add(new Card(CardFace.Eight, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Queen, CardSuit.Spades));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsOnePair(hand));
        }

        [TestMethod]
        public void TestTwoPairs()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Five, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Eight, CardSuit.Spades));
            cards.Add(new Card(CardFace.Eight, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Five, CardSuit.Spades));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsOnePair(hand));
        }

        // Should return false as the method only return true to "pure" one pairs.
        [TestMethod]
        public void TestThreeOfAKind()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Jack, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Jack, CardSuit.Spades));
            cards.Add(new Card(CardFace.Three, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Queen, CardSuit.Spades));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsOnePair(hand));
        }

        [TestMethod]
        public void TestFourOfAKind()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Jack, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Jack, CardSuit.Spades));
            cards.Add(new Card(CardFace.Three, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsOnePair(hand));
        }

        [TestMethod]
        public void TestFullHouse()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Jack, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Jack, CardSuit.Spades));
            cards.Add(new Card(CardFace.Three, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Three, CardSuit.Hearts));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsOnePair(hand));
        }
    }
}
