using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCell.GameModel
{
    public abstract class CardStack
    {

        public Card GetCard(int levelDeep)
        {
            if (levelDeep >= CardList.Count)
            {
                throw new Exception("Can't get beyond the depth of this Stack");
            }
            return CardList[CardList.Count-1 - levelDeep];
        }

        public abstract String ErrorMessage { get; }
        public List<Card> CardList { get; set; }

        public List<Card> GetCardsFromTop(int numberToGet)
        {
            List<Card> toRet = CardList.GetRange(CardList.Count - numberToGet, numberToGet);
            return toRet;
        }
        public List<Card> Remove(int numberToRemove)
        {
            if (numberToRemove > MaxNumberRemovable())
            {
                throw new Exception(ErrorMessage);
            }
            return UndoPlace(numberToRemove);
        }
        // void Place(List<Card> cards);
        public void Place(List<Card> cards)
        {
            if (!IsPlaceable(cards))
            {
                throw new Exception("Can't place cards here");
            }

            CardList.AddRange(cards);
        }
        public abstract int MaxNumberRemovable();
        public abstract bool IsPlaceable(List<Card> cards);

        public void UndoRemove(List<Card> cards)
        {
            CardList.AddRange(cards);
        }

        public List<Card> UndoPlace(int numberPlaced)
        {
            List<Card> toRet = CardList.GetRange(CardList.Count - numberPlaced, numberPlaced);
            CardList.RemoveRange(CardList.Count - numberPlaced, numberPlaced);
            return toRet;
        }
    }
}
