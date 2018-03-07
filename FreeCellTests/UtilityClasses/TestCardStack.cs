using FreeCell.GameModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCellTests.UtilityClasses
{
    class TestCardStack : CardStack
    {
        public override string ErrorMessage =>"Can't remove that many";

        public TestCardStack()
        {
            CardList = new List<Card>();
        }
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
