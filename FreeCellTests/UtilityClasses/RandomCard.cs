using FreeCell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCellTests.UtilityClasses
{
    class RandomCard
    {
        public static Random random = new Random();
        public static Array SuitValues = Enum.GetValues(typeof(Suit));
        public static Array RankValues = Enum.GetValues(typeof(Rank));

        public static Card GetRandomCard()
        {

            Suit randSuit = (Suit)SuitValues.GetValue(random.Next(SuitValues.Length));
            Rank randRank = (Rank)RankValues.GetValue(random.Next(RankValues.Length));

            return new Card(randSuit, randRank);

        }
    }
}
