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
        public static Suit[] SuitValues = (Suit[])Enum.GetValues(typeof(Suit));
        public static void PrintBoard(Board board)
        {
            Console.OutputEncoding = UnicodeEncoding.Unicode;
            Console.Clear();
            String emptyStack = " \u25a1 ";
            String empty = "   ";
            String columnSeperator = "  ";

            StringBuilder toPrint = new StringBuilder();

            foreach (Suit s in SuitValues)
            {
                Foundation found = board.Foundations[s];
                if (found.CardList.Count == 0)
                {
                    toPrint.Append(emptyStack);
                }
                else
                {
                    toPrint.Append(found.CardList[found.CardList.Count - 1].ToPrintString());
                }
                toPrint.Append(columnSeperator);
            }
            toPrint.Append(columnSeperator);

            foreach (FreeSpace space in board.FreeSpaces)
            {
                if (space.CardList.Count == 0)
                {
                    toPrint.Append(emptyStack);
                }
                else
                {
                    toPrint.Append(space.CardList[0].ToPrintString());
                }
                toPrint.Append(columnSeperator);
            }
            toPrint.AppendLine();
            toPrint.AppendLine();
            for (int depth = 0; depth < 19; depth++)
            {
                for (int width = 0; width < 8; width++)
                {
                    Cascade casc = board.Cascades[width];
                    if (casc.CardList.Count < depth + 1)
                    {
                        toPrint.Append(empty);
                    }
                    else
                    {
                        Card c = casc.CardList[depth];
                        toPrint.Append(c.ToPrintString());
                    }
                    toPrint.Append(columnSeperator);
                }
                toPrint.AppendLine();
            }

            toPrint.Append(board.MoveList.Count);
            Console.Write(toPrint.ToString());
        }


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
                    bool movedToFreeCell = false;
                    foreach (CardStack destination in destinations)
                    {
                        if (ReferenceEquals(destination, source))
                        {
                            continue;
                        }
                        if (source.GetType() == typeof(FreeSpace) &&
                            destination.GetType() == typeof(FreeSpace))
                        {
                            continue;
                        }

                        if (destination.IsPlaceable(cardList))
                        {
                            GameMove move = new GameMove(source, destination, i);
                            if (destination.GetType() == typeof(FreeSpace))
                            {
                                if (movedToFreeCell)
                                {
                                    break;
                                }
                                toRet.Add(move);
                                movedToFreeCell = true;
                            }
                            else
                            {
                                toRet.Add(move);
                            }


                        }
                    }
                }
            }

            toRet.Sort(
                (x, y) => x.numberToMove-y.numberToMove
                );
            foreach(var x in toRet)
            {
                Console.Write(" " + x.numberToMove);
            }
            return toRet;
        }
    }
}
