using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCell.GameModel
{
    public class GameMove
    {
        public CardStack source { get; set; }
        public CardStack destination { get; set; }
        public int numberToMove { get; set; }
        public GameMove(CardStack source, CardStack destination, int numberToMove)
        {
            this.source = source;
            this.destination = destination;
            this.numberToMove = numberToMove;
        }

        public void DoMove()
        {
            List<Card> movingCards = source.Remove(numberToMove);
            destination.Place(movingCards);
        }

        public void UndoMove()
        {
            List<Card> removingCards = destination.UndoPlace(numberToMove);
            source.UndoRemove(removingCards);
        }
    }
}
