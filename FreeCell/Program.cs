using FreeCell.GameModel;
using FreeCell.SolverLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCell
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            FreeCellGameSolver solver = new FreeCellGameSolver(board);
            solver.SolveAll();
            

        }
    }
}
