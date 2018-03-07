using Microsoft.VisualStudio.TestTools.UnitTesting;
using FreeCell.GameModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCell.GameModel.Tests
{
    [TestClass()]
    public class BoardTests
    {
        public Board board { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            board = new Board();
        }

        [TestMethod()]
        public void BoardTest()
        {

            foreach (FreeSpace space in board.FreeSpaces)
            {
                Assert.AreEqual(0, space.CardList.Count);
            }
            int totalCards = 0;

            for (int i = 0; i < 4; i++)
            {
                Cascade casc = board.Cascades[i];
                totalCards = totalCards + casc.CardList.Count;
                Assert.AreEqual(7, casc.CardList.Count);
            }
            for (int i = 4; i < 8; i++)
            {
                Cascade casc = board.Cascades[i];
                totalCards = totalCards + casc.CardList.Count;
                Assert.AreEqual(6, casc.CardList.Count);
            }
            Assert.AreEqual(52, totalCards);

            Assert.AreEqual(false, board.Foundations[Suit.Spades] == null);
            Assert.AreEqual(0, board.Foundations[Suit.Spades].CardList.Count);
            Assert.AreEqual(false, board.Foundations[Suit.Hearts] == null);
            Assert.AreEqual(0, board.Foundations[Suit.Hearts].CardList.Count);
            Assert.AreEqual(false, board.Foundations[Suit.Diamonds] == null);
            Assert.AreEqual(0, board.Foundations[Suit.Diamonds].CardList.Count);
            Assert.AreEqual(false, board.Foundations[Suit.Clubs] == null);
            Assert.AreEqual(0, board.Foundations[Suit.Clubs].CardList.Count);

        }

        [TestMethod()]
        public void GetBoardStateTest()
        {
            BoardState boardState1 = board.GetBoardState();
            BoardState boardState2 = board.GetBoardState();
            Assert.AreEqual(true, boardState1.Equals(boardState2));

            foreach (Suit s in board.Foundations.Keys)
            {
                Assert.IsTrue(board.Foundations[s].CardList.SequenceEqual(boardState1.Foundations[s]));
            }
            for(int i = 0; i < 4; i++)
            {

            }

        }

        [TestMethod()]
        public void DoMoveUndoMoveTest()
        {
            Assert.Fail();
        }


    }
}