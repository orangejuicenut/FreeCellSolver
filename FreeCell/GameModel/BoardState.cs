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
            this.FreeSpaces = new List<Card>();

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
        public List<Card> FreeSpaces { get; set; }

        public bool Equals(BoardState otherState)
        {
            bool cascsEqual = Cascades.SequenceEqual(otherState.Cascades);
            bool foundEqual = true;
            foreach(Suit s in Foundations.Keys)
            {
                foundEqual = foundEqual && (Foundations[s].SequenceEqual(otherState.Foundations[s]));
            }
            bool spaceEqual = FreeSpaces.SequenceEqual(otherState.FreeSpaces);

            return cascsEqual && foundEqual && spaceEqual;
        }

    }
}
