namespace Poker.TestHandComparison
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestSameTypeStraightFlush
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
                firstHandList.Add(new Card(CardFace.Jack, CardSuit.Clubs));
                firstHandList.Add(new Card(CardFace.Ten, CardSuit.Clubs));
                firstHandList.Add(new Card(CardFace.Nine, CardSuit.Clubs));
                Hand firstHand = new Hand(firstHandList);

                List<ICard> secondHandList = new List<ICard>();
                secondHandList.Add(new Card(CardFace.Ten, CardSuit.Spades));
                secondHandList.Add(new Card(CardFace.Eight, CardSuit.Spades));
                secondHandList.Add(new Card(CardFace.Nine, CardSuit.Spades));
                secondHandList.Add(new Card(CardFace.Jack, CardSuit.Spades));
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
                firstHandList.Add(new Card(CardFace.Jack, CardSuit.Clubs));
                firstHandList.Add(new Card(CardFace.Ten, CardSuit.Clubs));
                firstHandList.Add(new Card(CardFace.Nine, CardSuit.Clubs));
                Hand firstHand = new Hand(firstHandList);

                List<ICard> secondHandList = new List<ICard>();
                secondHandList.Add(new Card(CardFace.King, CardSuit.Spades));
                secondHandList.Add(new Card(CardFace.Jack, CardSuit.Spades));
                secondHandList.Add(new Card(CardFace.Queen, CardSuit.Spades));
                secondHandList.Add(new Card(CardFace.Ace, CardSuit.Spades));
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
                firstHandList.Add(new Card(CardFace.Jack, CardSuit.Clubs));
                firstHandList.Add(new Card(CardFace.Ten, CardSuit.Clubs));
                firstHandList.Add(new Card(CardFace.Nine, CardSuit.Clubs));
                Hand firstHand = new Hand(firstHandList);

                List<ICard> secondHandList = new List<ICard>();
                secondHandList.Add(new Card(CardFace.King, CardSuit.Spades));
                secondHandList.Add(new Card(CardFace.Jack, CardSuit.Spades));
                secondHandList.Add(new Card(CardFace.Queen, CardSuit.Spades));
                secondHandList.Add(new Card(CardFace.Nine, CardSuit.Spades));
                secondHandList.Add(new Card(CardFace.Ten, CardSuit.Spades));
                Hand secondHand = new Hand(secondHandList);

                PokerHandsChecker checker = new PokerHandsChecker();
                Assert.AreEqual(0, checker.CompareHands(firstHand, secondHand));
            }
        }
    }
}
