namespace Poker.TestHandComparison
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestSameTypeFlush
    {
        [TestMethod]
        public void TestFirstHandHigherFirstCard()
        {
            List<ICard> firstHandList = new List<ICard>();
            firstHandList.Add(new Card(CardFace.King, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Two, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Six, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Four, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            Hand firstHand = new Hand(firstHandList);

            List<ICard> secondHandList = new List<ICard>();
            secondHandList.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Nine, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Jack, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Five, CardSuit.Diamonds));
            Hand secondHand = new Hand(secondHandList);

            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.AreEqual(-1, checker.CompareHands(firstHand, secondHand));
        }

        [TestMethod]
        public void TestFirstHandHigherThirdCard()
        {
            List<ICard> firstHandList = new List<ICard>();
            firstHandList.Add(new Card(CardFace.King, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Two, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Six, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Four, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            Hand firstHand = new Hand(firstHandList);

            List<ICard> secondHandList = new List<ICard>();
            secondHandList.Add(new Card(CardFace.King, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Five, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Three, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            Hand secondHand = new Hand(secondHandList);

            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.AreEqual(-1, checker.CompareHands(firstHand, secondHand));
        }

        [TestMethod]
        public void TestSecondHandHigherSecondCard()
        {
            List<ICard> firstHandList = new List<ICard>();
            firstHandList.Add(new Card(CardFace.Queen, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Two, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Six, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Four, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            Hand firstHand = new Hand(firstHandList);

            List<ICard> secondHandList = new List<ICard>();
            secondHandList.Add(new Card(CardFace.King, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Five, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Three, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            Hand secondHand = new Hand(secondHandList);

            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.AreEqual(1, checker.CompareHands(firstHand, secondHand));
        }

        [TestMethod]
        public void TestSecondHandHigherFourthCard()
        {
            List<ICard> firstHandList = new List<ICard>();
            firstHandList.Add(new Card(CardFace.King, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Two, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Five, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Three, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            Hand firstHand = new Hand(firstHandList);

            List<ICard> secondHandList = new List<ICard>();
            secondHandList.Add(new Card(CardFace.King, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Five, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Four, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            Hand secondHand = new Hand(secondHandList);

            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.AreEqual(1, checker.CompareHands(firstHand, secondHand));
        }

        [TestMethod]
        public void TestEqualFlushes()
        {
            List<ICard> firstHandList = new List<ICard>();
            firstHandList.Add(new Card(CardFace.King, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Two, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Five, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Three, CardSuit.Clubs));
            firstHandList.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            Hand firstHand = new Hand(firstHandList);

            List<ICard> secondHandList = new List<ICard>();
            secondHandList.Add(new Card(CardFace.King, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Five, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Three, CardSuit.Diamonds));
            secondHandList.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            Hand secondHand = new Hand(secondHandList);

            PokerHandsChecker checker = new PokerHandsChecker();
            Assert.AreEqual(0, checker.CompareHands(firstHand, secondHand));
        }
    }
}
