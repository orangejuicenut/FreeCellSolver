using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCell.GameModel
{
    class Deck
    {
        public List<Card> Cards { get; set; }

        public Deck()
        {
            Cards = new List<Card>();
            foreach (Suit s in Enum.GetValues(typeof(Suit)))
            {
                for(Rank i = Rank.Ace; i <= Rank.King ; i++)
                {
                    Card card = new Card(s, i);
                    Cards.Add(card);
                }
            }
        }

        public void Shuffle()
        {
            Random r = new Random();
            Cards = Cards.OrderBy(i => r.Next()).ToList();
        }

    }
}
