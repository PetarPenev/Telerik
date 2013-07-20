namespace Poker
{
    using System;
    using System.Text;

    public class Card : ICard, IComparable<Card>
    {
        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public CardFace Face { get; private set; }

        public CardSuit Suit { get; private set; }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            bool areEqual = false;

            if (obj != null)
            {
                Card otherCard = obj as Card;
                if (otherCard != null)
                {
                    if ((this.Face == otherCard.Face) && (this.Suit == otherCard.Suit))
                    {
                        areEqual = true;
                    }
                }
            }

            return areEqual;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            switch (this.Face)
            {
                case (CardFace.Two):
                    {
                        sb.Append("2");
                        break;
                    }

                case (CardFace.Three):
                    {
                        sb.Append("3");
                        break;
                    }

                case (CardFace.Four):
                    {
                        sb.Append("4");
                        break;
                    }

                case (CardFace.Five):
                    {
                        sb.Append("5");
                        break;
                    }

                case (CardFace.Six):
                    {
                        sb.Append("6");
                        break;
                    }

                case (CardFace.Seven):
                    {
                        sb.Append("7");
                        break;
                    }

                case (CardFace.Eight):
                    {
                        sb.Append("8");
                        break;
                    }

                case (CardFace.Nine):
                    {
                        sb.Append("9");
                        break;
                    }

                case (CardFace.Ten):
                    {
                        sb.Append("10");
                        break;
                    }

                case (CardFace.Jack):
                    {
                        sb.Append("Jack");
                        break;
                    }

                case (CardFace.Queen):
                    {
                        sb.Append("Queen");
                        break;
                    }

                case (CardFace.King):
                    {
                        sb.Append("King");
                        break;
                    }

                case (CardFace.Ace):
                    {
                        sb.Append("Ace");
                        break;
                    }

                default:
                    {
                        throw new ArgumentException("Such card face does not exist.");
                    }
            }

            switch (this.Suit)
            {
                case (CardSuit.Clubs):
                    {
                        sb.Append("♣");
                        break;
                    }

                case (CardSuit.Diamonds):
                    {
                        sb.Append("♦");
                        break;
                    }

                case (CardSuit.Hearts):
                    {
                        sb.Append("♥");
                        break;
                    }

                case (CardSuit.Spades):
                    {
                        sb.Append("♠");
                        break;
                    }

                default:
                    {
                        throw new ArgumentException("Such card suit does not exist.");
                    }
            }

            return sb.ToString();
        }

        int IComparable<Card>.CompareTo(Card other)
        {
            if (this.Face > other.Face)
            {
                return 1;
            }
            else if (this.Face < other.Face)
            {
                return -1;
            }
            else
            {
                if (this.Suit > other.Suit)
                {
                    return 1;
                }
                else if (this.Suit < other.Suit)
                {
                    return -1;
                }

                return 0;
            }
        }
    }
}
