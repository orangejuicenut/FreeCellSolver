using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FreeCell;
using FreeCell.Tests;
using FreeCellTests.UtilityClasses;
using FreeCell.GameModel;

namespace FreeCellTests
{
    [TestClass]
    public class GameMoveTests
    {
        public CardStack stack1Test;
        public CardStack stack2Test;
        public CardStack stack1Orig;
        public CardStack stack2Orig;

        public int stackSize = 5;

        [TestInitialize()]
        public void Initialize()
        {
            stack1Test = new TestCardStack();
            stack1Orig = new TestCardStack();
            stack2Test = new TestCardStack();
            stack2Orig = new TestCardStack();

            for (int i = 0; i < stackSize; i++)
            {
                Card rand1 = RandomCard.GetRandomCard();
                Card rand2 = RandomCard.GetRandomCard();

                stack1Orig.CardList.Add(rand1);
                stack1Test.CardList.Add(rand1);
                stack2Orig.CardList.Add(rand2);
                stack2Test.CardList.Add(rand2);

            }
        }

        [TestMethod]
        public void MoveSingleCardFromStack()
        {
            GameMove move = new GameMove(stack1Test, stack2Test, 1);
            move.DoMove();

            Assert.AreEqual(stack1Test.CardList.Count, stackSize + 1);
            Assert.AreEqual(stack2Test.CardList.Count, stackSize - 1);

        }
        [TestMethod]
        public void MoveSingleCardFromStack2()
        {
            GameMove move = new GameMove(stack1Test, stack2Test, 1);
            move.DoMove();

            Assert.AreEqual(stack1Test.CardList.Count, stackSize + 1);
            Assert.AreEqual(stack2Test.CardList.Count, stackSize - 1);

        }
    }
}
