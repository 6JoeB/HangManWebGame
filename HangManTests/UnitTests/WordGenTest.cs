using HangManGame.Models;
using NUnit.Framework;

namespace HangManTests
{
    public class Tests
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
            var result = wordGenerator.RandomWordGetter();
            Assert.IsInstanceOf(typeof(string), result);
        }

        [Test]
        public void CheckRandomWordReturnedFromTextFile()
        {
            var result = wordGenerator.TextFileWordGetter();
            Assert.IsInstanceOf(typeof(string), result);
        }
    }
}