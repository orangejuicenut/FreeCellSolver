using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCell.GameModel
{
    public class Cascade : CardStack
    {
       
        public override string ErrorMessage => "Can't remove that many";

        public Cascade(List<Card> initialCards)
        {
            CardList = initialCards;
        }

        public override bool IsPlaceable(List<Card> cards)
        {
            if(CardList.Count == 0)
            {
                return true;
            }
            return CardList.Last().IsPlaceOnTopable(cards[0]);
        }

        public override int MaxNumberRemovable()
        {
            if (CardList.Count == 0 || CardList.Count==1)
            {
                return CardList.Count;
            }
            int count = 1;
            for (int i = CardList.Count - 1; i > 0; i--)
            {
                if (CardList[i - 1].IsPlaceOnTopable(CardList[i]))
                {
                    count++;
                }
                else
                {
                    return count;
                }
            }
            return count;
        }

       
    }
}
