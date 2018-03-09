using Microsoft.VisualStudio.TestTools.UnitTesting;
using FreeCell.GameModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCell.GameModel.Tests
{
    [TestClass]
    public class FoundationTests
    {
        public Foundation found { get; set; }
        [TestInitialize]
        public void Initialize()
        {
            found = new Foundation(Suit.Spades);
        }


        [TestMethod]
        public void GetTopWhenFoundationIsEmptyTest()
        {
            Assert.AreEqual(null, found.GetTop());
        }

        [TestMethod]
        public void PlaceAceAndTwoOnEmptyStack()
        {
            Assert.AreEqual(null, found.GetTop());
            Card ace = new Card(Suit.Spades, Rank.Ace);
            List<Card> temp = new List<Card>();
            temp.Add(ace);
            Assert.IsTrue(found.IsPlaceable(temp));
            found.Place(temp);
            Assert.AreEqual(ace, found.GetTop());


            temp.Remove(ace);
            Card two = new Card(Suit.Spades, Rank.Two);
            temp.Add(two);
            Assert.IsTrue(found.IsPlaceable(temp));
            found.Place(temp);
            Assert.AreEqual(two, found.GetTop());


        }

        [TestMethod]
        public void MaxNumberRemovableTest()
        {
            Assert.AreEqual(0, found.MaxNumberRemovable());
        }

        [TestMethod()]
        public void IsPlaceableTest()
        {

            Card ace = new Card(Suit.Clubs, Rank.Ace);
            List<Card> temp = new List<Card>();
            temp.Add(ace);
            Assert.IsFalse(found.IsPlaceable(temp));
            Card ace2 = new Card(Suit.Spades, Rank.Ace);
            temp.Remove(ace);
            temp.Add(ace2);
            temp.Add(ace);
            Assert.IsFalse(found.IsPlaceable(temp));
        }

        [TestMethod()]
        public void ErrorMessageTest()
        {
            Assert.AreEqual("Can't remove from Foundation", found.ErrorMessage);
        }
    }
}