namespace Poker.TestHandComparison
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestSameTypeFourOfAKind
    {
        [TestMethod]
        public void TestFirstHandThreeHigher()
        {
            List<ICard> firstHandList = new List<ICard>();
            firstHandList.Add(new Card(CardFace.King, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Nine, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.King, CardSuit.Hearts));
            firstHandList.Add(new Card(CardFace.King, CardSuit.Diamonds));
            firstHandList.Add(new Card(CardFace.King, CardSuit.Spades));
            Hand firstHand = new Hand(firstHandList);

            List<ICard> secondHandList = new List<ICard>();
            secondHandList.Add(new Card(CardFace.Queen, CardSuit.Clubs));
            secondHandList.Add(new Card(CardFace.Eight, CardSuit.Clubs));
            secondHandList.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            secondHandList.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Queen, CardSuit.Spades));
            Hand secondHand = new Hand(secondHandList);

            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.AreEqual(-1, checker.CompareHands(firstHand, secondHand));
        }

        [TestMethod]
        public void TestSecondHandThreeHigher()
        {
            List<ICard> firstHandList = new List<ICard>();
            firstHandList.Add(new Card(CardFace.King, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Nine, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.King, CardSuit.Hearts));
            firstHandList.Add(new Card(CardFace.King, CardSuit.Diamonds));
            firstHandList.Add(new Card(CardFace.King, CardSuit.Spades));
            Hand firstHand = new Hand(firstHandList);

            List<ICard> secondHandList = new List<ICard>();
            secondHandList.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            secondHandList.Add(new Card(CardFace.Eight, CardSuit.Clubs));
            secondHandList.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            secondHandList.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Ace, CardSuit.Spades));
            Hand secondHand = new Hand(secondHandList);

            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.AreEqual(1, checker.CompareHands(firstHand, secondHand));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestImpossibleEqualHands()
        {
            List<ICard> firstHandList = new List<ICard>();
            firstHandList.Add(new Card(CardFace.King, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Nine, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.King, CardSuit.Hearts));
            firstHandList.Add(new Card(CardFace.King, CardSuit.Diamonds));
            firstHandList.Add(new Card(CardFace.King, CardSuit.Spades));
            Hand firstHand = new Hand(firstHandList);

            List<ICard> secondHandList = new List<ICard>();
            secondHandList.Add(new Card(CardFace.King, CardSuit.Clubs));
            secondHandList.Add(new Card(CardFace.Eight, CardSuit.Clubs));
            secondHandList.Add(new Card(CardFace.King, CardSuit.Hearts));
            secondHandList.Add(new Card(CardFace.King, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.King, CardSuit.Spades));
            Hand secondHand = new Hand(secondHandList);

            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.AreEqual(1, checker.CompareHands(firstHand, secondHand));
        }
    }
}
