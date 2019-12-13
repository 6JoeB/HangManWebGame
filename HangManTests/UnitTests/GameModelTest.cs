using System;
using NUnit.Framework;
using HangManGame.Models;
using System.Collections.Generic;
using System.Linq;

namespace HangManTests

{
    [TestFixture]
    class GameModelTests
    {
        Game game;

        string word = "test";
        List<string> lettersAvailable = new List<string>(new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" });
        List<string> correctlyGuessed = new List<string>();
        List<string> incorrectlyGuessed = new List<string>();
        int numberOfGuesses;
        string guess = "";

        [SetUp]
        public void Setup()
        {
            game = new Game
            {
                Word = word,
                LettersAvailable = lettersAvailable,
                CorrectlyGuessed = correctlyGuessed,
                IncorrectlyGuessed = incorrectlyGuessed,
                NumberOfGuesses = numberOfGuesses,
                Guess = guess
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
            Assert.AreEqual(game.CorrectlyGuessed, correctlyGuessed);
        }

        [Test]
        public void GameHasLettersIncorrectlyGuessed()
        {
            Assert.AreEqual(game.IncorrectlyGuessed, incorrectlyGuessed);
        }

        [Test]
        public void GameHasNumberOfGuesses()
        {
            Assert.AreEqual(game.NumberOfGuesses, numberOfGuesses);
        }

        [Test]
        public void GameCanTakeGuess()
        {
            game.GetGuess("a");
            Assert.AreEqual(game.Guess, "a");
        }
    }
}
