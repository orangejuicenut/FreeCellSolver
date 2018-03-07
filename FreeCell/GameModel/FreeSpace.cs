using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCell.GameModel
{
    public class FreeSpace : CardStack
    {
        public FreeSpace()
        {
            CardList = new List<Card>();
        }

        public override string ErrorMessage => "Can't remove from Empty FreeSpace";
        public bool IsFree()
        {
            return CardList.Count == 0;
        }

        public override bool IsPlaceable(List<Card> cards)
        {
            return IsFree() && cards.Count==1;
        }
   
        public override int MaxNumberRemovable()
        {
            return CardList.Count;
        }

    }
}
