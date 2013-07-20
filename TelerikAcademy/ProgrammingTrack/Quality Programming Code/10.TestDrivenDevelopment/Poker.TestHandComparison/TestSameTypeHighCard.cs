namespace Poker.TestHandComparison
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestSameTypeHighCard
    {
        [TestMethod]
        public void TestFirstHighCardHandHigher()
        {
            List<ICard> firstHandList = new List<ICard>();
            firstHandList.Add(new Card(CardFace.King, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Eight, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Two, CardSuit.Hearts));
            firstHandList.Add(new Card(CardFace.Seven, CardSuit.Diamonds));
            firstHandList.Add(new Card(CardFace.Nine, CardSuit.Spades));
            Hand firstHand = new Hand(firstHandList);

            List<ICard> secondHandList = new List<ICard>();
            secondHandList.Add(new Card(CardFace.Nine, CardSuit.Clubs));
            secondHandList.Add(new Card(CardFace.Eight, CardSuit.Clubs));
            secondHandList.Add(new Card(CardFace.Two, CardSuit.Hearts));
            secondHandList.Add(new Card(CardFace.Three, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Queen, CardSuit.Spades));
            Hand secondHand = new Hand(secondHandList);

            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.AreEqual(-1, checker.CompareHands(firstHand, secondHand));
        }

        [TestMethod]
        public void TestFirstHighCardHandLower()
        {
            List<ICard> firstHandList = new List<ICard>();
            firstHandList.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Eight, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Two, CardSuit.Hearts));
            firstHandList.Add(new Card(CardFace.Seven, CardSuit.Diamonds));
            firstHandList.Add(new Card(CardFace.Nine, CardSuit.Spades));
            Hand firstHand = new Hand(firstHandList);

            List<ICard> secondHandList = new List<ICard>();
            secondHandList.Add(new Card(CardFace.Nine, CardSuit.Clubs));
            secondHandList.Add(new Card(CardFace.Eight, CardSuit.Clubs));
            secondHandList.Add(new Card(CardFace.Two, CardSuit.Hearts));
            secondHandList.Add(new Card(CardFace.Three, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Queen, CardSuit.Spades));
            Hand secondHand = new Hand(secondHandList);

            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.AreEqual(1, checker.CompareHands(firstHand, secondHand));
        }

        [TestMethod]
        public void TestFirstHighCardHandHigherInThirdCard()
        {
            List<ICard> firstHandList = new List<ICard>();
            firstHandList.Add(new Card(CardFace.Queen, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Eight, CardSuit.Hearts));
            firstHandList.Add(new Card(CardFace.Seven, CardSuit.Diamonds));
            firstHandList.Add(new Card(CardFace.Two, CardSuit.Spades));
            Hand firstHand = new Hand(firstHandList);

            List<ICard> secondHandList = new List<ICard>();
            secondHandList.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            secondHandList.Add(new Card(CardFace.Seven, CardSuit.Hearts));
            secondHandList.Add(new Card(CardFace.Three, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Two, CardSuit.Clubs));
            Hand secondHand = new Hand(secondHandList);

            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.AreEqual(-1, checker.CompareHands(firstHand, secondHand));
        }

        [TestMethod]
        public void TestFirstHighCardHandLowerInFourthCard()
        {
            List<ICard> firstHandList = new List<ICard>();
            firstHandList.Add(new Card(CardFace.Queen, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Eight, CardSuit.Hearts));
            firstHandList.Add(new Card(CardFace.Six, CardSuit.Diamonds));
            firstHandList.Add(new Card(CardFace.Two, CardSuit.Spades));
            Hand firstHand = new Hand(firstHandList);

            List<ICard> secondHandList = new List<ICard>();
            secondHandList.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            secondHandList.Add(new Card(CardFace.Eight, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Seven, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Two, CardSuit.Clubs));
            Hand secondHand = new Hand(secondHandList);

            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.AreEqual(1, checker.CompareHands(firstHand, secondHand));
        }

        [TestMethod]
        public void TestEqualHighCards()
        {
            List<ICard> firstHandList = new List<ICard>();
            firstHandList.Add(new Card(CardFace.Queen, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Eight, CardSuit.Hearts));
            firstHandList.Add(new Card(CardFace.Six, CardSuit.Diamonds));
            firstHandList.Add(new Card(CardFace.Two, CardSuit.Spades));
            Hand firstHand = new Hand(firstHandList);

            List<ICard> secondHandList = new List<ICard>();
            secondHandList.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            secondHandList.Add(new Card(CardFace.Eight, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Six, CardSuit.Spades));
            secondHandList.Add(new Card(CardFace.Two, CardSuit.Clubs));
            Hand secondHand = new Hand(secondHandList);

            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.AreEqual(0, checker.CompareHands(firstHand, secondHand));
        }
    }
}
