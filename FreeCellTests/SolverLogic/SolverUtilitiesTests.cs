using Microsoft.VisualStudio.TestTools.UnitTesting;
using FreeCell.SolverLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeCell.GameModel;

namespace FreeCell.SolverLogic.Tests
{
    [TestClass()]
    public class SolverUtilitiesTests
    {
        [TestMethod()]
        public void GetPossibleMovesTest()
        {
            Board board = new Board();
            List<GameMove> moves = SolverUtilities.GetPossibleMoves(board);
            BoardState initialState = board.GetBoardState();
            foreach(GameMove move in moves)
            {
                board.DoMove(move);
                BoardState moveState = board.GetBoardState();
                Assert.IsFalse(initialState.Equals(moveState));
                board.UndoMove();
                BoardState undoMoveState = board.GetBoardState();
                Assert.IsTrue(initialState.Equals(undoMoveState));
            }

        }
    }
}