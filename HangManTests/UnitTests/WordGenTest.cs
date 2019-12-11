using HangManGame.Models;
using NUnit.Framework;

namespace HangManTests
{
    [TestFixture]

    class WordGenTests
    {

        public wordGenerator wordGenerator;
        [SetUp]
        public void Setup()
        {
            wordGenerator = new wordGenerator();
        }

        [Test]
        public void CheckForArray()
        {
            var result = wordGenerator.randomWordGetter();
            Assert.IsInstanceOf(typeof(string), result);
        }
    }
}