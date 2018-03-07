using Microsoft.VisualStudio.TestTools.UnitTesting;
using FreeCellTests.UtilityClasses;
using FreeCell.GameModel;

namespace FreeCell.GameModel.Tests
{
    [TestClass]
    public class GameMoveTests
    {
        public CardStack sourceToModify;
        public CardStack destinationToModify;
        public CardStack sourceToCompare;
        public CardStack destinationToCompare;

        public int stackSize = 5;

        [TestInitialize()]
        public void Initialize()
        {
            sourceToModify = new TestCardStack();
            sourceToCompare = new TestCardStack();
            destinationToModify = new TestCardStack();
            destinationToCompare = new TestCardStack();

            for (int i = 0; i < stackSize; i++)
            {
                Card rand1 = RandomCard.GetRandomCard();
                Card rand2 = RandomCard.GetRandomCard();

                sourceToCompare.CardList.Add(rand1);
                sourceToModify.CardList.Add(rand1);
                destinationToCompare.CardList.Add(rand2);
                destinationToModify.CardList.Add(rand2);

            }
        }

        [TestMethod]
        public void MoveSingleCardFromStack()
        {
            GameMove move = new GameMove(sourceToModify, destinationToModify, 1);
            move.DoMove();

            Assert.AreEqual(stackSize - 1, sourceToModify.CardList.Count);
            Assert.AreEqual( stackSize + 1, destinationToModify.CardList.Count );

        }
        [TestMethod]
        public void UndoSingleMoveFromStack()
        {
            GameMove move = new GameMove(sourceToModify, destinationToModify, 1);
            move.UndoMove();

            Assert.AreEqual(stackSize + 1, sourceToModify.CardList.Count);
            Assert.AreEqual(stackSize - 1, destinationToModify.CardList.Count);

        }


    }
}
