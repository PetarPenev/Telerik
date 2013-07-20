namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    // All the methods in this class are indirectly unit tested in Poker.TestHandComparison project
    // as all of them are called by the CompareHand method of PokerHandsChecker class. Code coverage
    // according to DotCover is 97% (may be different if using the VisualStudioUltimate tool).
    public static class Compararer
    {
        public static int CompareHighCards(IHand firstHand, IHand secondHand)
        {
            List<CardFace> facesFirstHand = GetSortedFaces(firstHand);
            List<CardFace> facesSecondHand = GetSortedFaces(secondHand);

            return CompareFaceListsOfEqualLength(facesFirstHand, facesSecondHand);
        }

        public static int CompareOnePair(IHand firstHand, IHand secondHand)
        {
            List<CardFace> firstHandFaces = GetSortedFaces(firstHand);
            List<CardFace> secondHandFaces = GetSortedFaces(secondHand);

            CardFace firstHandPairFace = GetPairFace(firstHandFaces);
            CardFace secondHandPairFace = GetPairFace(secondHandFaces);

            if (firstHandPairFace > secondHandPairFace)
            {
                return -1;
            }
            else if (firstHandPairFace < secondHandPairFace)
            {
                return 1;
            }
            else
            {
                firstHandFaces.RemoveAll(face => face == firstHandPairFace);
                secondHandFaces.RemoveAll(face => face == secondHandPairFace);

                // Reverse so that the strongest card is in front
                firstHandFaces.Sort();
                firstHandFaces.Reverse();

                secondHandFaces.Sort();
                secondHandFaces.Reverse();

                return CompareFaceListsOfEqualLength(firstHandFaces, secondHandFaces);
            }
        }

        public static int CompareTwoPair(IHand firstHand, IHand secondHand)
        {
            // Since sortedFaces returns the array reverse sorted,
            // we can be certain that in case of a comparison
            // first we compare the highest pair than the lower one and then the kicker.
            List<CardFace> firstHandFaces = GetSortedFaces(firstHand);

            List<CardFace> secondHandFaces = GetSortedFaces(secondHand);

            CardFace firstHandPairFace = GetPairFace(firstHandFaces);
            CardFace secondHandPairFace = GetPairFace(secondHandFaces);

            if (firstHandPairFace > secondHandPairFace)
            {
                return -1;
            }
            else if (firstHandPairFace < secondHandPairFace)
            {
                return 1;
            }
            else
            {
                firstHandFaces.RemoveAll(face => face == firstHandPairFace);
                secondHandFaces.RemoveAll(face => face == secondHandPairFace);

                // No need to reverse as only one pair is left.
                firstHandFaces.Sort();
                secondHandFaces.Sort();

                firstHandPairFace = GetPairFace(firstHandFaces);
                secondHandPairFace = GetPairFace(secondHandFaces);

                if (firstHandPairFace > secondHandPairFace)
                {
                    return -1;
                }
                else if (firstHandPairFace < secondHandPairFace)
                {
                    return 1;
                }
                else
                {
                    firstHandFaces.RemoveAll(face => face == firstHandPairFace);
                    secondHandFaces.RemoveAll(face => face == secondHandPairFace);

                    if (firstHandFaces[0] > secondHandFaces[0])
                    {
                        return -1;
                    }
                    else if (firstHandFaces[0] < secondHandFaces[0])
                    {
                        return 1;
                    }
                }
            }

            return 0;
        }

        public static int CompareThreeOFAKind(IHand firstHand, IHand secondHand)
        {
            List<CardFace> firstHandFaces = GetSortedFaces(firstHand);
            List<CardFace> secondHandFaces = GetSortedFaces(secondHand);

            CardFace firstHandThreeFace = GetThreeFace(firstHandFaces);
            CardFace secondHandThreeFace = GetThreeFace(secondHandFaces);

            if (firstHandThreeFace > secondHandThreeFace)
            {
                return -1;
            }
            else if (firstHandThreeFace < secondHandThreeFace)
            {
                return 1;
            }

            throw new ArgumentException("Impossible to get such hands in a poker game.");
        }

        public static int CompareStraight(IHand firstHand, IHand secondHand)
        {
            // Again sorted in reverse order so we take the highest card
            List<CardFace> firstHandFaces = GetSortedFaces(firstHand);
            List<CardFace> secondHandFaces = GetSortedFaces(secondHand);

            CardFace firstHandHighest = firstHandFaces[firstHandFaces.Count - 1];
            CardFace secondHandHighest = secondHandFaces[secondHandFaces.Count - 1];

            if (firstHandHighest > secondHandHighest)
            {
                return -1;
            }
            else if (firstHandHighest < secondHandHighest)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }       

        public static int CompareFlush(IHand firstHand, IHand secondHand)
        {
            List<CardFace> firstHandFaces = GetSortedFaces(firstHand);
            List<CardFace> secondHandFaces = GetSortedFaces(secondHand);

            for (int i = 0; i < firstHandFaces.Count; i++)
            {
                if (firstHandFaces[i] > secondHandFaces[i])
                {
                    return -1;
                }
                else if (firstHandFaces[i] < secondHandFaces[i])
                {
                    return 1;
                }
            }

            return 0;
        }

        public static int CompareFullHouse(IHand firstHand, IHand secondHand)
        {
            List<CardFace> firstHandFaces = GetSortedFaces(firstHand);
            List<CardFace> secondHandFaces = GetSortedFaces(secondHand);

            CardFace firstHandThreeFace = GetThreeFace(firstHandFaces);
            CardFace secondHandThreeFace = GetThreeFace(secondHandFaces);

            if (firstHandThreeFace > secondHandThreeFace)
            {
                return -1;
            }
            else if (firstHandThreeFace < secondHandThreeFace)
            {
                return 1;
            }

            throw new ArgumentException("Such hands are not possible.");
        }

        public static int CompareFourOfAKind(IHand firstHand, IHand secondHand)
        {
            List<CardFace> firstHandFaces = GetSortedFaces(firstHand);
            List<CardFace> secondHandFaces = GetSortedFaces(secondHand);

            CardFace firstHandFourFace = firstHandFaces[0];
            if ((firstHandFourFace != firstHandFaces[1]) && (firstHandFourFace != firstHandFaces[2]))
            {
                firstHandFourFace = firstHandFaces[1];
            }

            CardFace secondHandFourFace = secondHandFaces[0];
            if ((secondHandFourFace != secondHandFaces[1]) && (secondHandFourFace != secondHandFaces[2]))
            {
                secondHandFourFace = secondHandFaces[1];
            }

            if (firstHandFourFace > secondHandFourFace)
            {
                return -1;
            }
            else if (firstHandFourFace < secondHandFourFace)
            {
                return 1;
            }

            throw new ArgumentException("It is impossible to have two same Four of a kinds.");
        }

        public static int CompareStraightFlush(IHand firstHand, IHand secondHand)
        {
            List<CardFace> firstHandFaces = GetSortedFaces(firstHand);
            List<CardFace> secondHandFaces = GetSortedFaces(secondHand);

            // Reversely sorted by strenght so we take the last cards.
            if (firstHandFaces[firstHandFaces.Count - 1] > secondHandFaces[secondHandFaces.Count - 1])
            {
                return -1;
            }
            else if (firstHandFaces[firstHandFaces.Count - 1] < secondHandFaces[secondHandFaces.Count - 1])
            {
                return 1;
            }

            return 0;
        }

        private static CardFace GetThreeFace(List<CardFace> sortedFaces)
        {
            for (int i = 1; i < sortedFaces.Count - 1; i++)
            {
                if ((sortedFaces[i] == sortedFaces[i - 1]) && (sortedFaces[i] == sortedFaces[i + 1]))
                {
                    return sortedFaces[i];
                }
            }

            throw new ArgumentException("No three of a kind detected");
        }

        private static CardFace GetPairFace(List<CardFace> sortedFaces)
        {
            for (int i = 1; i < sortedFaces.Count; i++)
            {
                if (sortedFaces[i] == sortedFaces[i - 1])
                {
                    if ((i == sortedFaces.Count - 1) || (sortedFaces[i] != sortedFaces[i + 1]))
                    {
                        return sortedFaces[i];
                    }
                }
            }

            throw new ArgumentException("No pair detected");
        }

        private static int CompareFaceListsOfEqualLength(List<CardFace> firstList, List<CardFace> secondList)
        {
            for (int i = 0; i < firstList.Count; i++)
            {
                if (firstList[i] > secondList[i])
                {
                    return -1;
                }
                else if (firstList[i] < secondList[i])
                {
                    return 1;
                }
            }

            return 0;
        }

        private static List<CardFace> GetSortedFaces(IHand hand)
        {
            List<CardFace> faces = new List<CardFace>();
            for (int i = 0; i < hand.Cards.Count; i++)
            {
                faces.Add(hand.Cards[i].Face);
            }

            faces.Sort();
            faces.Reverse();
            return faces;
        }
    }
}
