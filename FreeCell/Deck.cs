using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCell
{
    class Deck
    {
        public List<Card> cards { get; set; }

        public Deck()
        {
            cards = new List<Card>();
            foreach (Suit s in Enum.GetValues(typeof(Suit)))
            {
                for(Rank i = Rank.Ace; i <= Rank.King ; i++)
                {
                    Card card = new Card(s, i);
                    cards.Add(card);
                }
            }
        }

        public void Shuffle()
        {
            Random r = new Random();
            cards = cards.OrderBy(i => r.Next()).ToList();
        }

    }
}
