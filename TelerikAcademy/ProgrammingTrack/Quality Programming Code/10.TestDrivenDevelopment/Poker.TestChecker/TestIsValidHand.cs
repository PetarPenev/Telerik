namespace Poker.TestChecker
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestCheckerValidHand
    {
        [TestMethod]
        public void TestEmptyHand()
        {
            Hand hand = new Hand(new List<ICard>());
            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.IsFalse(checker.IsValidHand(hand));
        }

        [TestMethod]
        public void TestOneCardHand()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsValidHand(hand));
        }

        [TestMethod]
        public void TestFourCardHand()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsValidHand(hand));
        }

        [TestMethod]
        public void TestSixCardHand()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsValidHand(hand));
        }

        [TestMethod]
        public void TestFiveCardHand()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsValidHand(hand));
        }

        // This test should fail as there cannot be more than one card of a certain
        // face and suit.
        [TestMethod]
        public void TestFiveEqualCardHand()
        {
            List<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsValidHand(hand));
        }
    }
}
