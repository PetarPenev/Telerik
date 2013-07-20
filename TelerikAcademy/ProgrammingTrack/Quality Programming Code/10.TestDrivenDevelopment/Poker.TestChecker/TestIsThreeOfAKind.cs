namespace Poker.TestChecker
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestCheckerIsThreeOfAKind
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

            Assert.IsFalse(checker.IsThreeOfAKind(hand));
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

            Assert.IsFalse(checker.IsThreeOfAKind(hand));
        }

        [TestMethod]
        public void TestPair()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Five, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Eight, CardSuit.Spades));
            cards.Add(new Card(CardFace.Three, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Five, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Queen, CardSuit.Spades));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsThreeOfAKind(hand));
        }

        [TestMethod]
        public void TestThreeOfAKind()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Five, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Eight, CardSuit.Spades));
            cards.Add(new Card(CardFace.Three, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Five, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Five, CardSuit.Spades));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsThreeOfAKind(hand));
        }

        // Should fail as method is designed to count only pure three of a kind
        // as three of a kind.
        [TestMethod]
        public void TestFullHouse()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Five, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Eight, CardSuit.Spades));
            cards.Add(new Card(CardFace.Eight, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Five, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Five, CardSuit.Spades));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsThreeOfAKind(hand));
        }

        // Should fail as method is designed to count only pure three of a kind
        // as three of a kind.
        [TestMethod]
        public void TestFourOfAKind()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Five, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Eight, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Five, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Five, CardSuit.Spades));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsThreeOfAKind(hand));
        }
    }
}