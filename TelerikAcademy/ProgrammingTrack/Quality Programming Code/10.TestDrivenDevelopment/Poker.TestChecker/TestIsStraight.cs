namespace Poker.TestChecker
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestCheckerIsStraight
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

            Assert.IsFalse(checker.IsStraight(hand));
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

            Assert.IsFalse(checker.IsStraight(hand));
        }

        [TestMethod]
        public void TestOneShortOfStraight()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Five, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Six, CardSuit.Spades));
            cards.Add(new Card(CardFace.Seven, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Eight, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Three, CardSuit.Spades));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsStraight(hand));
        }

        // Should pass because straights need at least 2 suits
        [TestMethod]
        public void TestOnlyOneSuit()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Five, CardSuit.Spades));
            cards.Add(new Card(CardFace.Six, CardSuit.Spades));
            cards.Add(new Card(CardFace.Seven, CardSuit.Spades));
            cards.Add(new Card(CardFace.Eight, CardSuit.Spades));
            cards.Add(new Card(CardFace.Nine, CardSuit.Spades));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsStraight(hand));
        }

        [TestMethod]
        public void TestStraightTwoSuits()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Five, CardSuit.Spades));
            cards.Add(new Card(CardFace.Six, CardSuit.Spades));
            cards.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Eight, CardSuit.Spades));
            cards.Add(new Card(CardFace.Nine, CardSuit.Spades));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsStraight(hand));
        }

        [TestMethod]
        public void TestStraightMultipleSuits()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Six, CardSuit.Spades));
            cards.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Eight, CardSuit.Spades));
            cards.Add(new Card(CardFace.Nine, CardSuit.Diamonds));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsStraight(hand));
        }
    }
}
