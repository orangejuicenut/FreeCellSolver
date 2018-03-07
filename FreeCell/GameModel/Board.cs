using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCell.GameModel
{
    public class Board
    {
        private Deck deck = new Deck();

        public Cascade[] Cascades { get; set; }
        public Dictionary<Suit, Foundation> Foundations { get; set; }
        public FreeSpace[] FreeSpaces { get; set; }

        private Stack<GameMove> MoveList = new Stack<GameMove>();
        public Board()
        {
            deck.Shuffle();
            Foundations = new Dictionary<Suit, Foundation>();
            Suit[] SuitValues = (Suit[])Enum.GetValues(typeof(Suit));
            foreach (Suit suit in SuitValues)
            {
                Foundation toAdd = new Foundation(suit);
                Foundations.Add(suit, toAdd);
            }
            FreeSpaces = new FreeSpace[4];
            for(int i = 0; i < FreeSpaces.Length; i++)
            {
                FreeSpaces[i] = new FreeSpace();
            }
            List<Card>[] initialCards = new List<Card>[8];
            int count = 0;
            foreach(Card card in deck.Cards)
            {
                if (initialCards[count] == null)
                {
                    initialCards[count] = new List<Card>();
                }
                initialCards[count].Add(card);
                count++;
                if (count == 8)
                {
                    count = 0;
                }
            }
            
            Cascades = new Cascade[8];
            for (int i = 0; i < Cascades.Length; i++)
            {
                Cascades[i] = new Cascade(initialCards[i]);
            }

        }

        public BoardState GetBoardState()
        {
            return new BoardState(Cascades, Foundations, FreeSpaces);
        }

        public void DoMove(GameMove move)
        {
            MoveList.Push(move);
            move.DoMove();
        }

        public void UndoMove()
        {
            GameMove move = MoveList.Pop();
            move.UndoMove();
        }
        
    }
}
