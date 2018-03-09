using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCell.GameModel
{
    public class BoardState
    {
        public BoardState(Cascade[] Cascades,
          Dictionary<Suit, Foundation> Foundations,
          FreeSpace[] FreeSpaces)
        {
            this.Cascades = new List<List<Card>>();
            this.Foundations = new Dictionary<Suit, List<Card>>();
            this.FreeSpaces = new HashSet<Card>();

            foreach (Cascade casc in Cascades)
            {
                this.Cascades.Add(new List<Card>(casc.CardList));
            }
            foreach (Suit found in Foundations.Keys)
            {
                this.Foundations.Add(found, new List<Card>(Foundations[found].CardList));
            }
            foreach (FreeSpace space in FreeSpaces)
            {
                if (space.CardList.Count != 0)
                {
                    this.FreeSpaces.Add(space.CardList[0]);
                }
                else
                {
                    this.FreeSpaces.Add(null);
                }
            }
        }
        public List<List<Card>> Cascades { get; set; }
        public Dictionary<Suit, List<Card>> Foundations { get; set; }
        public HashSet<Card> FreeSpaces { get; set; }

        public bool Equals(BoardState otherState)
        {
            //bool cascsEqual = true;// Cascades.SequenceEqual(otherState.Cascades);

            Suit s = Suit.Spades;
            if (!Foundations[s].SequenceEqual(otherState.Foundations[s]))
            {
                return false;
            }
            s = Suit.Clubs;
            if (!Foundations[s].SequenceEqual(otherState.Foundations[s]))
            {
                return false;
            }
            s = Suit.Diamonds;
            if (!Foundations[s].SequenceEqual(otherState.Foundations[s]))
            {
                return false;
            }
            s = Suit.Hearts;
            if (!Foundations[s].SequenceEqual(otherState.Foundations[s]))
            {
                return false;
            }

            if (!FreeSpaces.SetEquals(otherState.FreeSpaces))
            {
                return false;
            }


            foreach (List<Card> casc in this.Cascades)
            {
                bool isMatch = false;
                foreach (List<Card> other in otherState.Cascades)
                {
                    if (other.SequenceEqual(casc))
                    {
                        isMatch = true;
                    }
                }
                if (!isMatch)
                {
                    return false;
                }
            }

            /*
            for (int i = 0; i < Cascades.Count; i++)
            {
                cascsEqual = cascsEqual && Cascades[i].SequenceEqual(otherState.Cascades[i]);
            }
            */

        

            return true;
        }

    }
}
