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
    public class FreeCellGameSolverTests
    {
        public FreeCellGameSolver solver { get; set; }
        
        [TestInitialize]
        public void Initialize()
        {
            Board board = new Board();
            solver = new FreeCellGameSolver(board);
        }


        [TestMethod()]
        public void FreeCellGameSolverSolveAllTest()
        {
            solver.SolveAll();
            Assert.IsTrue(solver.board.CheckVictory());
        }
    }
}