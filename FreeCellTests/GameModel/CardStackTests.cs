using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FreeCellTests.UtilityClasses;
using FreeCell.GameModel;

namespace FreeCellTests.GameModel
{

    [TestClass]
    public class CardStackTests
    {
       

        
        
        [TestMethod]
        public void GetCardTest()
        {
            TestCardStack cards = new TestCardStack();
            Card c = RandomCard.GetRandomCard();
            cards.CardList.Add(c);
            Card d = cards.GetCard(0);
            Assert.AreEqual(c, d);
                
        }
    }
}
