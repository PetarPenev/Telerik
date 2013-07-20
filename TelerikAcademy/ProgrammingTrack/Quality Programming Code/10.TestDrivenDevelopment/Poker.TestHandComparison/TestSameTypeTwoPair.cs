namespace Poker.TestHandComparison
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestSameTypeTwoPair
    {
        [TestMethod]
        public void TestFirstHandHigherBothPairs()
        {
            List<ICard> firstHandList = new List<ICard>();
            firstHandList.Add(new Card(CardFace.King, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Nine, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Two, CardSuit.Hearts));
            firstHandList.Add(new Card(CardFace.King, CardSuit.Diamonds));
            firstHandList.Add(new Card(CardFace.Nine, CardSuit.Spades));
            Hand firstHand = new Hand(firstHandList);

            List<ICard> secondHandList = new List<ICard>();
            secondHandList.Add(new Card(CardFace.Nine, CardSuit.Clubs));
            secondHandList.Add(new Card(CardFace.Eight, CardSuit.Clubs));
            secondHandList.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            secondHandList.Add(new Card(CardFace.Eight, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Queen, CardSuit.Spades));
            Hand secondHand = new Hand(secondHandList);

            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.AreEqual(-1, checker.CompareHands(firstHand, secondHand));
        }

        [TestMethod]
        public void TestSecondHandHigherBothPairs()
        {
            List<ICard> firstHandList = new List<ICard>();
            firstHandList.Add(new Card(CardFace.Six, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Nine, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Two, CardSuit.Hearts));
            firstHandList.Add(new Card(CardFace.Six, CardSuit.Diamonds));
            firstHandList.Add(new Card(CardFace.Nine, CardSuit.Spades));
            Hand firstHand = new Hand(firstHandList);

            List<ICard> secondHandList = new List<ICard>();
            secondHandList.Add(new Card(CardFace.Nine, CardSuit.Clubs));
            secondHandList.Add(new Card(CardFace.Ten, CardSuit.Clubs));
            secondHandList.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            secondHandList.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Queen, CardSuit.Spades));
            Hand secondHand = new Hand(secondHandList);

            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.AreEqual(1, checker.CompareHands(firstHand, secondHand));
        }

        [TestMethod]
        public void TestFirstHandHigherOnePairHigherFirst()
        {
            List<ICard> firstHandList = new List<ICard>();
            firstHandList.Add(new Card(CardFace.King, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Nine, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Two, CardSuit.Hearts));
            firstHandList.Add(new Card(CardFace.King, CardSuit.Diamonds));
            firstHandList.Add(new Card(CardFace.Nine, CardSuit.Spades));
            Hand firstHand = new Hand(firstHandList);

            List<ICard> secondHandList = new List<ICard>();
            secondHandList.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Ten, CardSuit.Hearts));
            secondHandList.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            secondHandList.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Queen, CardSuit.Spades));
            Hand secondHand = new Hand(secondHandList);

            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.AreEqual(-1, checker.CompareHands(firstHand, secondHand));
        }

        [TestMethod]
        public void TestFirstHandHigherOnePairHigherSecond()
        {
            List<ICard> firstHandList = new List<ICard>();
            firstHandList.Add(new Card(CardFace.King, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Nine, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Two, CardSuit.Hearts));
            firstHandList.Add(new Card(CardFace.King, CardSuit.Diamonds));
            firstHandList.Add(new Card(CardFace.Nine, CardSuit.Spades));
            Hand firstHand = new Hand(firstHandList);

            List<ICard> secondHandList = new List<ICard>();
            secondHandList.Add(new Card(CardFace.Three, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Three, CardSuit.Hearts));
            secondHandList.Add(new Card(CardFace.King, CardSuit.Hearts));
            secondHandList.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.King, CardSuit.Spades));
            Hand secondHand = new Hand(secondHandList);

            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.AreEqual(-1, checker.CompareHands(firstHand, secondHand));
        }

        [TestMethod]
        public void TestSecondHandHigherOnePairHigherFirst()
        {
            List<ICard> firstHandList = new List<ICard>();
            firstHandList.Add(new Card(CardFace.King, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Nine, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Two, CardSuit.Hearts));
            firstHandList.Add(new Card(CardFace.King, CardSuit.Diamonds));
            firstHandList.Add(new Card(CardFace.Nine, CardSuit.Spades));
            Hand firstHand = new Hand(firstHandList);

            List<ICard> secondHandList = new List<ICard>();
            secondHandList.Add(new Card(CardFace.Nine, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Nine, CardSuit.Hearts));
            secondHandList.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            secondHandList.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Ace, CardSuit.Spades));
            Hand secondHand = new Hand(secondHandList);

            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.AreEqual(1, checker.CompareHands(firstHand, secondHand));
        }

        [TestMethod]
        public void TestSecondHandHigherOnePairHigherSecond()
        {
            List<ICard> firstHandList = new List<ICard>();
            firstHandList.Add(new Card(CardFace.King, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Two, CardSuit.Hearts));
            firstHandList.Add(new Card(CardFace.King, CardSuit.Diamonds));
            firstHandList.Add(new Card(CardFace.Seven, CardSuit.Spades));
            Hand firstHand = new Hand(firstHandList);

            List<ICard> secondHandList = new List<ICard>();
            secondHandList.Add(new Card(CardFace.Nine, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Nine, CardSuit.Hearts));
            secondHandList.Add(new Card(CardFace.King, CardSuit.Hearts));
            secondHandList.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.King, CardSuit.Spades));
            Hand secondHand = new Hand(secondHandList);

            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.AreEqual(1, checker.CompareHands(firstHand, secondHand));
        }

        [TestMethod]
        public void TestTwoPairsEqualFirstHandKickerHigher()
        {
            List<ICard> firstHandList = new List<ICard>();
            firstHandList.Add(new Card(CardFace.King, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            firstHandList.Add(new Card(CardFace.King, CardSuit.Diamonds));
            firstHandList.Add(new Card(CardFace.Seven, CardSuit.Spades));
            Hand firstHand = new Hand(firstHandList);

            List<ICard> secondHandList = new List<ICard>();
            secondHandList.Add(new Card(CardFace.Seven, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Seven, CardSuit.Hearts));
            secondHandList.Add(new Card(CardFace.King, CardSuit.Hearts));
            secondHandList.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.King, CardSuit.Spades));
            Hand secondHand = new Hand(secondHandList);

            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.AreEqual(-1, checker.CompareHands(firstHand, secondHand));
        }

        [TestMethod]
        public void TestTwoPairsEqualSecondHandKickerHigher()
        {
            List<ICard> firstHandList = new List<ICard>();
            firstHandList.Add(new Card(CardFace.King, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            firstHandList.Add(new Card(CardFace.King, CardSuit.Diamonds));
            firstHandList.Add(new Card(CardFace.Seven, CardSuit.Spades));
            Hand firstHand = new Hand(firstHandList);

            List<ICard> secondHandList = new List<ICard>();
            secondHandList.Add(new Card(CardFace.Seven, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Seven, CardSuit.Hearts));
            secondHandList.Add(new Card(CardFace.King, CardSuit.Hearts));
            secondHandList.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.King, CardSuit.Spades));
            Hand secondHand = new Hand(secondHandList);

            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.AreEqual(1, checker.CompareHands(firstHand, secondHand));
        }

        [TestMethod]
        public void TestTwoPairsEqualKickersEqual()
        {
            List<ICard> firstHandList = new List<ICard>();
            firstHandList.Add(new Card(CardFace.King, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            firstHandList.Add(new Card(CardFace.King, CardSuit.Diamonds));
            firstHandList.Add(new Card(CardFace.Seven, CardSuit.Spades));
            Hand firstHand = new Hand(firstHandList);

            List<ICard> secondHandList = new List<ICard>();
            secondHandList.Add(new Card(CardFace.Seven, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Seven, CardSuit.Hearts));
            secondHandList.Add(new Card(CardFace.King, CardSuit.Hearts));
            secondHandList.Add(new Card(CardFace.Jack, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.King, CardSuit.Spades));
            Hand secondHand = new Hand(secondHandList);

            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.AreEqual(0, checker.CompareHands(firstHand, secondHand));
        }
    }
}
