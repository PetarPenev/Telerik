namespace Poker.TestHandComparison
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestSameTypeStraight
    {
        [TestClass]
        public class TestSameHandTwoPair
        {
            [TestMethod]
            public void TestFirstHandHigher()
            {
                List<ICard> firstHandList = new List<ICard>();
                firstHandList.Add(new Card(CardFace.King, CardSuit.Clubs));
                firstHandList.Add(new Card(CardFace.Queen, CardSuit.Clubs));
                firstHandList.Add(new Card(CardFace.Jack, CardSuit.Hearts));
                firstHandList.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
                firstHandList.Add(new Card(CardFace.Nine, CardSuit.Spades));
                Hand firstHand = new Hand(firstHandList);

                List<ICard> secondHandList = new List<ICard>();
                secondHandList.Add(new Card(CardFace.Ten, CardSuit.Clubs));
                secondHandList.Add(new Card(CardFace.Eight, CardSuit.Clubs));
                secondHandList.Add(new Card(CardFace.Nine, CardSuit.Hearts));
                secondHandList.Add(new Card(CardFace.Jack, CardSuit.Diamonds));
                secondHandList.Add(new Card(CardFace.Seven, CardSuit.Spades));
                Hand secondHand = new Hand(secondHandList);

                PokerHandsChecker checker = new PokerHandsChecker();
                Assert.AreEqual(-1, checker.CompareHands(firstHand, secondHand));
            }

            [TestMethod]
            public void TestSecondHandHigher()
            {
                List<ICard> firstHandList = new List<ICard>();
                firstHandList.Add(new Card(CardFace.King, CardSuit.Clubs));
                firstHandList.Add(new Card(CardFace.Queen, CardSuit.Clubs));
                firstHandList.Add(new Card(CardFace.Jack, CardSuit.Hearts));
                firstHandList.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
                firstHandList.Add(new Card(CardFace.Nine, CardSuit.Spades));
                Hand firstHand = new Hand(firstHandList);

                List<ICard> secondHandList = new List<ICard>();
                secondHandList.Add(new Card(CardFace.King, CardSuit.Hearts));
                secondHandList.Add(new Card(CardFace.Jack, CardSuit.Clubs));
                secondHandList.Add(new Card(CardFace.Queen, CardSuit.Hearts));
                secondHandList.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
                secondHandList.Add(new Card(CardFace.Ten, CardSuit.Spades));
                Hand secondHand = new Hand(secondHandList);

                PokerHandsChecker checker = new PokerHandsChecker();
                Assert.AreEqual(1, checker.CompareHands(firstHand, secondHand));
            }

            [TestMethod]
            public void TestEqual()
            {
                List<ICard> firstHandList = new List<ICard>();
                firstHandList.Add(new Card(CardFace.King, CardSuit.Clubs));
                firstHandList.Add(new Card(CardFace.Queen, CardSuit.Clubs));
                firstHandList.Add(new Card(CardFace.Jack, CardSuit.Hearts));
                firstHandList.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
                firstHandList.Add(new Card(CardFace.Nine, CardSuit.Spades));
                Hand firstHand = new Hand(firstHandList);

                List<ICard> secondHandList = new List<ICard>();
                secondHandList.Add(new Card(CardFace.King, CardSuit.Hearts));
                secondHandList.Add(new Card(CardFace.Jack, CardSuit.Clubs));
                secondHandList.Add(new Card(CardFace.Queen, CardSuit.Hearts));
                secondHandList.Add(new Card(CardFace.Nine, CardSuit.Diamonds));
                secondHandList.Add(new Card(CardFace.Ten, CardSuit.Spades));
                Hand secondHand = new Hand(secondHandList);

                PokerHandsChecker checker = new PokerHandsChecker();
                Assert.AreEqual(0, checker.CompareHands(firstHand, secondHand));
            }
        }
    }
}
