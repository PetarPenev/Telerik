namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Hand : IHand
    {
        public Hand(List<ICard> cards)
        {
            this.Cards = cards;
        }

        public IList<ICard> Cards { get; private set; }

        public override string ToString()
        {
            if (this.Cards.Count == 0)
            {
                throw new ArgumentException("No cards in the hand present.");
            }

            StringBuilder sb = new StringBuilder();

            foreach (var card in this.Cards)
            {
                sb.Append(card.ToString() + " ");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
