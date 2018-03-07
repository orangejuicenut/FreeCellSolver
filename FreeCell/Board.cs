using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCell
{
    class Board
    {
        private Deck deck = new Deck();
        private List<Card>[] cascades = new List<Card>[8];
        private List<Card>[] foundations = new List<Card>[4];

        public Board()
        {
            deck.Shuffle();
        }
        
    }
}
