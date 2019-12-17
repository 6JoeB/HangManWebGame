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
        public void DifficultyCanBeSetToHard()
        {
            Assert.AreEqual(5, (int)Difficulty.hard);
        }

        [Test]
        public void DifficultyCanBeSetToMedium()
        {
            Assert.AreEqual(10, (int)Difficulty.medium);
        }
    }
}
