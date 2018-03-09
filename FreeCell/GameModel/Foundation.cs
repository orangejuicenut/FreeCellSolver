using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCell.GameModel
{
    public class Foundation : CardStack
    {
        public Card GetTop()
        {
            if (CardList.Count == 0)
            {
                return null;
            }
            return CardList.Last();
        }


        public override int MaxNumberRemovable()
        {
            return 0;
        }

        public bool CheckVictory()
        {
            return CardList.Count == 13;
        }

        public override bool IsPlaceable(List<Card> cards)
        {
            if (cards.Count != 1)
            {
                return false;
            }
            Card placee = cards[0];
            if (CardList.Count==0 && placee.suit == suit && placee.rank == Rank.Ace)
            {
                return true;
            }
            
            if (CardList.Count != 0 && placee.suit == suit && GetTop().rank + 1 == placee.rank)
            {
                return true;
            }
            return false;
        }



        public Suit suit { get { return mysuit; } }

        public override string ErrorMessage => "Can't remove from Foundation";

        private Suit mysuit;
        public Foundation(Suit s)
        {
            CardList = new List<Card>();
            mysuit = s;
        }
    }
}
