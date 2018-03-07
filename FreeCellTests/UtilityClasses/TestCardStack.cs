using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCell.Tests
{
    class TestCardStack : CardStack
    {
        public override string ErrorMessage =>"Can't remove that many";

        public override bool IsPlaceable(List<Card> cards)
        {
            return true;
        }

        public override int MaxNumberRemovable()
        {
            return this.CardList.Count;
        }

       
    }
}
