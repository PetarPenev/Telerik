namespace Poker.TestHandComparison
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CompareDifferentHands
    {
        [TestMethod]
        public void CompareFirstHandTwoPairSecondThreeOfAKind()
        {
            List<ICard> firstHandList = new List<ICard>();
            firstHandList.Add(new Card(CardFace.King, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Eight, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Two, CardSuit.Hearts));
            firstHandList.Add(new Card(CardFace.King, CardSuit.Diamonds));
            firstHandList.Add(new Card(CardFace.Eight, CardSuit.Spades));
            Hand firstHand = new Hand(firstHandList);

            List<ICard> secondHandList = new List<ICard>();
            secondHandList.Add(new Card(CardFace.Nine, CardSuit.Clubs));
            secondHandList.Add(new Card(CardFace.Eight, CardSuit.Clubs));
            secondHandList.Add(new Card(CardFace.Two, CardSuit.Hearts));
            secondHandList.Add(new Card(CardFace.Nine, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Nine, CardSuit.Spades));
            Hand secondHand = new Hand(secondHandList);

            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.AreEqual(1, checker.CompareHands(firstHand, secondHand));
        }

        [TestMethod]
        public void CompareFirstHandOnePairSecondFullHouse()
        {
            List<ICard> firstHandList = new List<ICard>();
            firstHandList.Add(new Card(CardFace.King, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Eight, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Two, CardSuit.Hearts));
            firstHandList.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            firstHandList.Add(new Card(CardFace.Eight, CardSuit.Spades));
            Hand firstHand = new Hand(firstHandList);

            List<ICard> secondHandList = new List<ICard>();
            secondHandList.Add(new Card(CardFace.Nine, CardSuit.Clubs));
            secondHandList.Add(new Card(CardFace.Two, CardSuit.Clubs));
            secondHandList.Add(new Card(CardFace.Two, CardSuit.Hearts));
            secondHandList.Add(new Card(CardFace.Nine, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Nine, CardSuit.Spades));
            Hand secondHand = new Hand(secondHandList);

            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.AreEqual(1, checker.CompareHands(firstHand, secondHand));
        }

        [TestMethod]
        public void CompareFirstHandFlushSecondHighCard()
        {
            List<ICard> firstHandList = new List<ICard>();
            firstHandList.Add(new Card(CardFace.King, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Eight, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Two, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Queen, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Six, CardSuit.Clubs));
            Hand firstHand = new Hand(firstHandList);

            List<ICard> secondHandList = new List<ICard>();
            secondHandList.Add(new Card(CardFace.Nine, CardSuit.Clubs));
            secondHandList.Add(new Card(CardFace.Two, CardSuit.Clubs));
            secondHandList.Add(new Card(CardFace.Three, CardSuit.Hearts));
            secondHandList.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Ace, CardSuit.Spades));
            Hand secondHand = new Hand(secondHandList);

            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.AreEqual(-1, checker.CompareHands(firstHand, secondHand));
        }

        [TestMethod]
        public void CompareFirstHandStraightFlushSecondStraight()
        {
            List<ICard> firstHandList = new List<ICard>();
            firstHandList.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            firstHandList.Add(new Card(CardFace.Jack, CardSuit.Diamonds));
            firstHandList.Add(new Card(CardFace.Nine, CardSuit.Diamonds));
            firstHandList.Add(new Card(CardFace.Eight, CardSuit.Diamonds));
            firstHandList.Add(new Card(CardFace.Seven, CardSuit.Diamonds));
            Hand firstHand = new Hand(firstHandList);

            List<ICard> secondHandList = new List<ICard>();
            secondHandList.Add(new Card(CardFace.Nine, CardSuit.Clubs));
            secondHandList.Add(new Card(CardFace.Ten, CardSuit.Clubs));
            secondHandList.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            secondHandList.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.King, CardSuit.Spades));
            Hand secondHand = new Hand(secondHandList);

            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.AreEqual(-1, checker.CompareHands(firstHand, secondHand));
        }
    }
}
