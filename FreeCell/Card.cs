using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCell
{
    public enum Suit { Spades, Hearts, Diamonds,  Clubs }
    public enum Rank : int
    {
        King = 13,
        Queen = 12,
        Jack = 11,
        Ten = 10,
        Nine = 9,
        Eight = 8,
        Seven = 7,
        Six = 6,
        Five = 5,
        Four = 4,
        Three = 3,
        Two = 2,
        Ace = 1
    }
    public enum Color { Red, Black }
    class Card
    {


        private Suit mysuit;
        private Rank myrank;
        public Color color
        {
            get
            {
                if (mysuit == Suit.Spades || mysuit == Suit.Clubs)
                {
                    return Color.Black;
                }
                return Color.Red;
            }
        }

        public Card Copy()
        {
            return new Card(mysuit, myrank);
        }

        public bool IsPlaceable(Card other)
        {
            if (other.color != this.color && this.rank - 1 == other.rank)
            {
                return true;
            }

            return false;
        }

        public Rank rank { get { return myrank; } }
        public Suit suit { get { return mysuit; } }

        public Card(Suit s, Rank r)
        {
            myrank = r;
            mysuit = s;
        }
    }
}
