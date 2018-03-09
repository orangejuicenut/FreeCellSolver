using Microsoft.VisualStudio.TestTools.UnitTesting;
using FreeCell.GameModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeCellTests.UtilityClasses;

namespace FreeCell.GameModel.Tests
{
    [TestClass()]
    public class FreeSpaceTests
    {
        public FreeSpace space { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            space = new FreeSpace();
        }
   

        [TestMethod()]
        public void FreeSpaceIsFreeTest()
        {
            Assert.IsTrue(space.IsFree());
            Card c = RandomCard.GetRandomCard();
            List<Card> temp = new List<Card>();
            temp.Add(c);
            space.Place(temp);
            Assert.IsFalse(space.IsFree());
        }

        [TestMethod()]
        public void IsPlaceableTest()
        {
            Card c = RandomCard.GetRandomCard();
            List<Card> temp = new List<Card>();
            temp.Add(c);
            temp.Add(c);
            Assert.IsFalse(space.IsPlaceable(temp));
            temp.Remove(c);
            Assert.IsTrue(space.IsPlaceable(temp));
            space.Place(temp);
            Assert.IsFalse(space.IsPlaceable(temp));

        }

        [TestMethod()]
        public void MaxNumberRemovableTest()
        {
            Assert.AreEqual(0, space.MaxNumberRemovable());
            Card c = RandomCard.GetRandomCard();
            List<Card> temp = new List<Card>();
            temp.Add(c);
            space.Place(temp);
            Assert.AreEqual(1, space.MaxNumberRemovable());
        }

        public void ErrorMessageTest()
        {
            Assert.AreEqual("Can't remove from Empty FreeSpace", space.ErrorMessage);
        }
    }
}