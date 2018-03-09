using FreeCell.GameModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCell.SolverLogic
{
    public class SolverUtilities
    {
        public static List<GameMove> GetPossibleMoves(Board board)
        {
            List<GameMove> toRet = new List<GameMove>();
            List<CardStack> sources = board.Cascades.Concat<CardStack>(board.FreeSpaces).ToList();
            List<CardStack> destinations = sources.Concat<CardStack>(board.Foundations.Values).ToList();

            foreach (CardStack source in sources)
            {
                int maxNum = Math.Min(source.MaxNumberRemovable(), board.GetFreeSpaces() + 1);
                for (int i = 1; i <= maxNum; i++)
                {
                    List<Card> cardList = source.GetCardsFromTop(i);
                    foreach (CardStack destination in destinations)
                    {
                        if (ReferenceEquals(destination, source)){
                            continue;
                        }

                        if (destination.IsPlaceable(cardList))
                        {
                            GameMove move = new GameMove(source, destination, i);
                            toRet.Add(move);
                        }
                    }
                }
            }

            return toRet;
        }
    }
}
