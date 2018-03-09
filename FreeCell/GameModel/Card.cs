using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCell.GameModel
{
    public enum Suit { Spades, Hearts, Diamonds, Clubs }
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
    public class Card
    {

        public String ToPrintString()
        {
            String toRet = "";
            if (mysuit == Suit.Spades)
            {
                toRet = '\u2660' + toRet;
            }
            else if (mysuit == Suit.Hearts)
            {
                toRet = '\u2665' + toRet;
            }
            else if (mysuit == Suit.Diamonds)
            {
                toRet = '\u2666' + toRet;
            }
            else if (mysuit == Suit.Clubs)
            {
                toRet = '\u2663' + toRet;
            }
            if (myrank >= Rank.Two && myrank <= Rank.Nine)
            {
                toRet = " " + (int)myrank + toRet;
            }
            else if (myrank == Rank.Ace)
            {
                toRet = " A" + toRet;
            }
            else if (myrank == Rank.Ten)
            {
                toRet = "10" + toRet;
            }
            else if (myrank == Rank.Jack)
            {
                toRet = " J" + toRet;
            }
            else if (myrank == Rank.Queen)
            {
                toRet = " Q" + toRet;
            }
            else if (myrank == Rank.King)
            {
                toRet = " K" + toRet;
            }
            return toRet;
        }

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

        public bool IsPlaceOnTopable(Card placee)
        {
            if (placee.color != this.color && this.rank - 1 == placee.rank)
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
