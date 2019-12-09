using System;
using NUnit.Framework;
using HangManGame.Models;

namespace HangManTests

{
    [TestFixture]
    class GameModelTests
    {
        Game game;

        string word = "test";
        string[] lettersAvailable = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        string[] lettersCorrectlyGuessed = { };
        string[] lettersIncorrectlyGuessed = { };

        [SetUp]
        public void Setup()
        {
            game = new Game
            {
                Word = word,
                LettersAvailable = lettersAvailable,
                LettersCorrectlyGuessed = lettersCorrectlyGuessed,
                LettersIncorrectlyGuessed = lettersIncorrectlyGuessed;
            };
        }

        [Test]
        public void CreatesAnInstanceOfGame()
        {
            Assert.That(game, Is.InstanceOf<Game>());
        }

        [Test]
        public void GameHasWord()
        {
            Assert.AreEqual(game.Word, word);
        }

        [Test]
        public void GameHasLettersAvailable()
        {
            Assert.AreEqual(game.LettersAvailable, lettersAvailable);
        }

        [Test]
        public void GameHasLettersCorrectlyGuessed()
        {
            Assert.AreEqual(game.LettersCorrectlyGuessed, lettersCorrectlyGuessed);
        }

        [Test]
        public void GameHasLettersIncorrectlyGuessed()
        {
            Assert.AreEqual(game.LettersIncorrectlyGuessed, lettersIncorrectlyGuessed);
        }
}
}