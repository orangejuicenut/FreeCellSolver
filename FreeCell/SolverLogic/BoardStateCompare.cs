using FreeCell.GameModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCell.SolverLogic
{
    class BoardStateCompare : IEqualityComparer<BoardState>
    {
        private static BoardStateCompare comp = new BoardStateCompare();
        public static BoardStateCompare Comparer { get { return comp; } }

        public bool Equals(BoardState x, BoardState y)
        {
            return x.Equals(y);
        }

        public int GetHashCode(BoardState obj)
        {
            return obj.GetHashCode();
        }
    }
}
