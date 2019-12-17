using HangManGame.Models;
using NUnit.Framework;
using System;

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
        public void CheckRandomWordReturnedFromTextFile()
        {
            var result = wordGenerator.TextFileWordGetter();
            Assert.IsInstanceOf(typeof(string), result);
        }
    }
}