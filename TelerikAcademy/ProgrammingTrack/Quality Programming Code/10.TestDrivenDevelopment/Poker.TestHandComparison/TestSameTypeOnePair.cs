namespace Poker.TestHandComparison
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestSameTypeOnePair
    {
        [TestMethod]
        public void TestFirstPairHigher()
        {
            List<ICard> firstHandList = new List<ICard>();
            firstHandList.Add(new Card(CardFace.King, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Eight, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Two, CardSuit.Hearts));
            firstHandList.Add(new Card(CardFace.King, CardSuit.Diamonds));
            firstHandList.Add(new Card(CardFace.Nine, CardSuit.Spades));
            Hand firstHand = new Hand(firstHandList);

            List<ICard> secondHandList = new List<ICard>();
            secondHandList.Add(new Card(CardFace.Nine, CardSuit.Clubs));
            secondHandList.Add(new Card(CardFace.Eight, CardSuit.Clubs));
            secondHandList.Add(new Card(CardFace.Two, CardSuit.Hearts));
            secondHandList.Add(new Card(CardFace.Eight, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Queen, CardSuit.Spades));
            Hand secondHand = new Hand(secondHandList);

            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.AreEqual(-1, checker.CompareHands(firstHand, secondHand));
        }

        [TestMethod]
        public void TestSecondPairHigher()
        {
            List<ICard> firstHandList = new List<ICard>();
            firstHandList.Add(new Card(CardFace.King, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Eight, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Two, CardSuit.Hearts));
            firstHandList.Add(new Card(CardFace.King, CardSuit.Diamonds));
            firstHandList.Add(new Card(CardFace.Nine, CardSuit.Spades));
            Hand firstHand = new Hand(firstHandList);

            List<ICard> secondHandList = new List<ICard>();
            secondHandList.Add(new Card(CardFace.Nine, CardSuit.Clubs));
            secondHandList.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            secondHandList.Add(new Card(CardFace.Two, CardSuit.Hearts));
            secondHandList.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Queen, CardSuit.Spades));
            Hand secondHand = new Hand(secondHandList);

            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.AreEqual(1, checker.CompareHands(firstHand, secondHand));
        }

        [TestMethod]
        public void TestEqualPairsFirstHandHigher()
        {
            List<ICard> firstHandList = new List<ICard>();
            firstHandList.Add(new Card(CardFace.King, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Eight, CardSuit.Hearts));
            firstHandList.Add(new Card(CardFace.Four, CardSuit.Hearts));
            firstHandList.Add(new Card(CardFace.King, CardSuit.Diamonds));
            firstHandList.Add(new Card(CardFace.Nine, CardSuit.Spades));
            Hand firstHand = new Hand(firstHandList);

            List<ICard> secondHandList = new List<ICard>();
            secondHandList.Add(new Card(CardFace.Three, CardSuit.Clubs));
            secondHandList.Add(new Card(CardFace.Eight, CardSuit.Clubs));
            secondHandList.Add(new Card(CardFace.King, CardSuit.Hearts));
            secondHandList.Add(new Card(CardFace.Nine, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.King, CardSuit.Spades));
            Hand secondHand = new Hand(secondHandList);

            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.AreEqual(-1, checker.CompareHands(firstHand, secondHand));
        }

        [TestMethod]
        public void TestEqualPairsSecondHandHigher()
        {
            List<ICard> firstHandList = new List<ICard>();
            firstHandList.Add(new Card(CardFace.King, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Eight, CardSuit.Hearts));
            firstHandList.Add(new Card(CardFace.Four, CardSuit.Hearts));
            firstHandList.Add(new Card(CardFace.King, CardSuit.Diamonds));
            firstHandList.Add(new Card(CardFace.Nine, CardSuit.Spades));
            Hand firstHand = new Hand(firstHandList);

            List<ICard> secondHandList = new List<ICard>();
            secondHandList.Add(new Card(CardFace.Three, CardSuit.Clubs));
            secondHandList.Add(new Card(CardFace.Eight, CardSuit.Clubs));
            secondHandList.Add(new Card(CardFace.King, CardSuit.Hearts));
            secondHandList.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.King, CardSuit.Spades));
            Hand secondHand = new Hand(secondHandList);

            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.AreEqual(1, checker.CompareHands(firstHand, secondHand));
        }

        [TestMethod]
        public void TestEqualPairsEqualOtherCards()
        {
            List<ICard> firstHandList = new List<ICard>();
            firstHandList.Add(new Card(CardFace.King, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Eight, CardSuit.Hearts));
            firstHandList.Add(new Card(CardFace.Three, CardSuit.Hearts));
            firstHandList.Add(new Card(CardFace.King, CardSuit.Diamonds));
            firstHandList.Add(new Card(CardFace.Ten, CardSuit.Spades));
            Hand firstHand = new Hand(firstHandList);

            List<ICard> secondHandList = new List<ICard>();
            secondHandList.Add(new Card(CardFace.Three, CardSuit.Clubs));
            secondHandList.Add(new Card(CardFace.Eight, CardSuit.Clubs));
            secondHandList.Add(new Card(CardFace.King, CardSuit.Hearts));
            secondHandList.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.King, CardSuit.Spades));
            Hand secondHand = new Hand(secondHandList);

            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.AreEqual(0, checker.CompareHands(firstHand, secondHand));
        }
    }
}
