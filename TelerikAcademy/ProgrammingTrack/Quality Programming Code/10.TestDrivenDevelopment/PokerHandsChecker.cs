namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            bool isValid = hand.Cards.Count == 5;

            // Check if there are two cards that are the same - that means the deck is
            // rigged and the hand is invalid.
            if (isValid)
            {
                for (int i = 0; i < hand.Cards.Count - 1; i++)
                {
                    for (int j = i + 1; j < hand.Cards.Count; j++)
                    {
                        if (hand.Cards[i].Equals(hand.Cards[j]))
                        {
                            isValid = false;
                            break;
                        }
                    }
                }
            }

            return isValid;
        }

        public bool IsStraightFlush(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Hand is not valid.");
            }

            bool isFlush = this.IsFlush(hand);
            bool isStraightFlush = false;
            if (isFlush)
            {
                List<CardFace> faces = new List<CardFace>();
                foreach (var card in hand.Cards)
                {
                    faces.Add(card.Face);
                }

                faces.Sort();
                
                isStraightFlush = true;
                for (int i = 1; i < faces.Count; i++)
                {
                    if (faces[i] - faces[i - 1] != 1)
                    {
                        isStraightFlush = false;
                    }
                }
            }

            return isStraightFlush;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Hand is not valid.");
            }

            CardFace face = CardFace.Ace;
            int numberOfFaces = 0;
            bool isFourOfAKind = false;

            List<CardFace> faces = new List<CardFace>();
            for (int i = 0; i < hand.Cards.Count; i++)
            {
                faces.Add(hand.Cards[i].Face);
            }

            faces.Sort();

            // We need to check only for the faces of two of the cards because if two
            // cards do not have faces that form a four of a kind, the left three cards
            // cannot form one on their own.
            for (int i = 0; i < 2; i++)
            {
                numberOfFaces = 1;
                face = faces[i];
                for (int j = i + 1; j < faces.Count; j++)
                {
                    if (face == faces[j])
                    {
                        numberOfFaces++;
                    }
                }

                if (numberOfFaces == 4)
                {
                    isFourOfAKind = true;
                }
            }

            return isFourOfAKind;
        }

        public bool IsFullHouse(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Hand is not valid.");
            }

            List<CardFace> faces = new List<CardFace>();
            foreach (var card in hand.Cards)
            {
                faces.Add(card.Face);   
            }

            faces.Sort();
            CardFace currentCardFace = faces[0];

            int numberOfFacesInHand = 1;
            for (int i = 1; i < faces.Count; i++)
            {
                if (faces[i] != faces[i - 1])
                {
                    numberOfFacesInHand++;
                }
            }

            return ((numberOfFacesInHand == 2) && !(this.IsFourOfAKind(hand)));
        }

        // Return True in every case of Flush including straight flush
        public bool IsFlush(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Hand is not valid.");
            }

            bool isFlush = true;
            CardSuit suit = hand.Cards[0].Suit;
            for (int i = 1; i < hand.Cards.Count; i++)
            {
                if (hand.Cards[i].Suit != suit)
                {
                    isFlush = false;
                }
            }

            return isFlush;
        }

        public bool IsStraight(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Hand is not valid.");
            }

            bool isStraight = true;

            List<CardFace> faces = new List<CardFace>();
            foreach (var card in hand.Cards)
            {
                faces.Add(card.Face);
            }

            faces.Sort();
            for (int i = 1; i < faces.Count; i++)
            {
                if (faces[i] - faces[i - 1] != 1)
                {
                    isStraight = false;
                }
            }

            if (isStraight)
            {
                List<CardSuit> suits = new List<CardSuit>();
                foreach (var card in hand.Cards)
                {
                    suits.Add(card.Suit);
                }

                suits.Sort();
                for (int i = 1; i < suits.Count; i++)
                {
                    if (suits[i] != suits[i - 1])
                    {
                        break;
                    }

                    if (i == suits.Count - 1)
                    {
                        isStraight = false;
                    }
                }
            }

            return isStraight;
        }

        // Return true only if the hand is three of a kind - and not if it is
        // full house or four of a kind
        public bool IsThreeOfAKind(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Hand is not valid.");
            }

            List<CardFace> faces = new List<CardFace>();
            foreach (var card in hand.Cards)
            {
                faces.Add(card.Face);
            }

            faces.Sort();

            int longestSequence = 1;
            int currentSequence = 1;
            for (int i = 1; i < faces.Count; i++)
            {
                if (faces[i] != faces[i - 1])
                {
                    if (currentSequence > longestSequence)
                    {
                        longestSequence = currentSequence;
                    }

                    currentSequence = 0;
                }

                currentSequence++;
            }

            // Accounting for the last sequence.
            if (currentSequence > longestSequence)
            {
                longestSequence = currentSequence;
            }

            return ((longestSequence == 3) && !(this.IsFullHouse(hand)));
        }

        // Return true only if the hand is exactly two pairs - meaning
        // false to full house, etc.
        public bool IsTwoPair(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Hand is not valid.");
            }

            Tuple<int, int> pairInformation = this.DetermineNumberOfPairs(hand);

            return ((pairInformation.Item1 == 2) && (pairInformation.Item2 == 2));
        }

        // Return true only if the hand is exactly one pair - meaning
        // false to full house, two pair, etc.
        public bool IsOnePair(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Hand is not valid.");
            }

            Tuple<int, int> pairInformation = this.DetermineNumberOfPairs(hand);

            return ((pairInformation.Item1 == 1) && (pairInformation.Item2 == 2));
        }

        public bool IsHighCard(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Hand is not valid.");
            }

            bool handHasNoCombination = !(this.IsOnePair(hand) || this.IsTwoPair(hand)
                || this.IsFourOfAKind(hand) || this.IsStraight(hand) || this.IsFlush(hand)
                || this.IsStraightFlush(hand) || this.IsThreeOfAKind(hand) || this.IsFullHouse(hand));

            return handHasNoCombination;
        }

        // Return -1 when firstHand is stronger, 0 when equal and 1 when second hand is
        // stronger.
        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            Debug.Assert(this.IsValidHand(firstHand));
            Debug.Assert(this.IsValidHand(secondHand));

            HandCombination firstHandCombinations = this.GetHandCombination(firstHand);
            HandCombination secondHandCombination = this.GetHandCombination(secondHand);

            if (firstHandCombinations > secondHandCombination)
            {
                return -1;
            }
            else if (firstHandCombinations < secondHandCombination)
            {
                return 1;
            }
            else
            {
                if (firstHandCombinations == HandCombination.HighCard)
                {
                    return Compararer.CompareHighCards(firstHand, secondHand);
                }
                else if (firstHandCombinations == HandCombination.OnePair)
                {
                    return Compararer.CompareOnePair(firstHand, secondHand);
                }
                else if (firstHandCombinations == HandCombination.TwoPair)
                {
                    return Compararer.CompareTwoPair(firstHand, secondHand);
                }
                else if (firstHandCombinations == HandCombination.ThreeOfAKind)
                {
                    return Compararer.CompareThreeOFAKind(firstHand, secondHand);
                }
                else if (firstHandCombinations == HandCombination.Straight)
                {
                    return Compararer.CompareStraight(firstHand, secondHand);
                }
                else if (firstHandCombinations == HandCombination.Flush)
                {
                    return Compararer.CompareFlush(firstHand, secondHand);
                }
                else if (firstHandCombinations == HandCombination.FullHouse)
                {
                    return Compararer.CompareFullHouse(firstHand, secondHand);
                }
                else if (firstHandCombinations == HandCombination.FourOfAKind)
                {
                    return Compararer.CompareFourOfAKind(firstHand, secondHand);
                }
                else if (firstHandCombinations == HandCombination.StraightFlush)
                {
                    return Compararer.CompareStraightFlush(firstHand, secondHand);
                }
            }

            throw new ArgumentException("All kinds of hands were exhausted - obviously an error.");
        }

        private HandCombination GetHandCombination(IHand hand)
        {
            HandCombination handCombination = HandCombination.HighCard;

            if (this.IsStraightFlush(hand))
            {
                handCombination = HandCombination.StraightFlush;
            }
            else if (this.IsFourOfAKind(hand))
            {
                handCombination = HandCombination.FourOfAKind;
            }
            else if (this.IsFullHouse(hand))
            {
                handCombination = HandCombination.FullHouse;
            }
            else if (this.IsFlush(hand))
            {
                handCombination = HandCombination.Flush;
            }
            else if (this.IsStraight(hand))
            {
                handCombination = HandCombination.Straight;
            }
            else if (this.IsThreeOfAKind(hand))
            {
                handCombination = HandCombination.ThreeOfAKind;
            }
            else if (this.IsTwoPair(hand))
            {
                handCombination = HandCombination.TwoPair;
            }
            else if (this.IsOnePair(hand))
            {
                handCombination = HandCombination.OnePair;
            }

            return handCombination;
        }

        private Tuple<int, int> DetermineNumberOfPairs(IHand hand)
        {
            List<CardFace> faces = new List<CardFace>();
            foreach (var card in hand.Cards)
            {
                faces.Add(card.Face);
            }

            faces.Sort();

            int numberOfPairs = 0;
            int currentSequence = 1;
            int longestSequence = 1;
            for (int i = 1; i < faces.Count; i++)
            {
                if (faces[i] != faces[i - 1])
                {
                    if (currentSequence == 2)
                    {
                        numberOfPairs++;
                    }

                    if (currentSequence > longestSequence)
                    {
                        longestSequence = currentSequence;
                    }

                    currentSequence = 0;
                }

                currentSequence++;
            }

            // Accounting for the last sequence.
            if (currentSequence == 2)
            {
                numberOfPairs++;
            }

            if (currentSequence > longestSequence)
            {
                longestSequence = currentSequence;
            }

            return new Tuple<int, int>(numberOfPairs, longestSequence);
        }
    }
}
