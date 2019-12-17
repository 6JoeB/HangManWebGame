using System;
using System.Collections.Generic;
using System.Text;
using HangManGame.Logic;
using NUnit.Framework;

namespace HangManTests.UnitTests
{
    [TestFixture]
    class DifficultyLogicTest
    {
        [Test]
        public void GameCanSetDifficultyToHard()
        {
            Assert.AreEqual(5, (int)Difficulty.hard);
        }
    }
}
