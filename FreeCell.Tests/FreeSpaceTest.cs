// <copyright file="FreeSpaceTest.cs" company="USCIS">Copyright © USCIS 2018</copyright>
using System;
using System.Collections.Generic;
using FreeCell.GameModel;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FreeCell.GameModel.Tests
{
    /// <summary>This class contains parameterized unit tests for FreeSpace</summary>
    [PexClass(typeof(FreeSpace))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class FreeSpaceTest
    {
        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        internal FreeSpace ConstructorTest()
        {
            FreeSpace target = new FreeSpace();
            return target;
            // TODO: add assertions to method FreeSpaceTest.ConstructorTest()
        }

        /// <summary>Test stub for get_ErrorMessage()</summary>
        [PexMethod]
        internal string ErrorMessageGetTest([PexAssumeUnderTest]FreeSpace target)
        {
            string result = target.ErrorMessage;
            return result;
            // TODO: add assertions to method FreeSpaceTest.ErrorMessageGetTest(FreeSpace)
        }

        /// <summary>Test stub for IsFree()</summary>
        [PexMethod]
        internal bool IsFreeTest([PexAssumeUnderTest]FreeSpace target)
        {
            bool result = target.IsFree();
            return result;
            // TODO: add assertions to method FreeSpaceTest.IsFreeTest(FreeSpace)
        }

        /// <summary>Test stub for IsPlaceable(List`1&lt;Card&gt;)</summary>
        [PexMethod]
        internal bool IsPlaceableTest([PexAssumeUnderTest]FreeSpace target, List<Card> cards)
        {
            bool result = target.IsPlaceable(cards);
            return result;
            // TODO: add assertions to method FreeSpaceTest.IsPlaceableTest(FreeSpace, List`1<Card>)
        }

        /// <summary>Test stub for MaxNumberRemovable()</summary>
        [PexMethod]
        internal int MaxNumberRemovableTest([PexAssumeUnderTest]FreeSpace target)
        {
            int result = target.MaxNumberRemovable();
            return result;
            // TODO: add assertions to method FreeSpaceTest.MaxNumberRemovableTest(FreeSpace)
        }
    }
}
