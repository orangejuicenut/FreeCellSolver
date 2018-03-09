using FreeCell.GameModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCell.SolverLogic
{
    public class FreeCellGameSolver
    {
        public Board board { get; set; }
        public Stack<List<GameMove>> possibleMoves { get; set; }
        public Stack<BoardState> boardStates { get; set; }

        public int stepCount = 0;

        public FreeCellGameSolver(Board b)
        {
            board = b;
            possibleMoves = new Stack<List<GameMove>>();
            boardStates = new Stack<BoardState>();
        }

        public void SolveAll()
        {
            SolverUtilities.PrintBoard(board);
            while (board.CheckVictory()!= true)
            {
                SingleStep();
                Console.ReadKey();
                SolverUtilities.PrintBoard(board);
                
            }
        }
        public void SingleStep()
        {
            if (possibleMoves.Count == 0)
            {
                possibleMoves.Push(SolverUtilities.GetPossibleMoves(board));
            }
            List<GameMove> moves = possibleMoves.Peek();
            while (moves.Count == 0)
            {
                possibleMoves.Pop();
                board.UndoMove();
                boardStates.Pop();
                moves = possibleMoves.Peek();
                stepCount--;
            }
            GameMove move = moves[moves.Count - 1];
            moves.Remove(move);
            boardStates.Push(board.GetBoardState());
            board.DoMove(move);
            BoardState newState = board.GetBoardState();

            
            if (boardStates.Contains(newState, BoardStateCompare.Comparer))
            {
                board.UndoMove();
                boardStates.Pop();
                stepCount--;
                return;
            }

            List<GameMove> newPossibleMoves = SolverUtilities.GetPossibleMoves(board);
            possibleMoves.Push(newPossibleMoves);
            stepCount++;
            return;
            
        }



    }
}
