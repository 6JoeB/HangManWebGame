using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;
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
        string answer = "";
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
                Answer = answer,
                LettersAvailable = lettersAvailable,
                CorrectlyGuessed = correctlyGuessed,
                IncorrectlyGuessed = incorrectlyGuessed,
                NumberOfGuesses = numberOfGuesses,
                Guess = guess
            };
            game.CorrectlyGuessed.Clear();
            game.IncorrectlyGuessed.Clear();
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
        public void GameHasAnswer()
        {
            Assert.AreEqual(game.Answer, answer);
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
        public void GameCanSetDifficulty()
        {
            game.SetDifficulty("Hard");
            Assert.AreEqual(numberOfGuesses, 5);
        }

        [Test]
        public void GameHasNumberOfGuesses()
        {
            Assert.AreEqual(game.NumberOfGuesses, numberOfGuesses);
        }

        [Test]
        public void GameCreatesAnswerWithDashesEqualToLengthOfWord()
        {
            game.GenerateAnswer();
            Assert.AreEqual(game.Answer.Length, game.Word.Length);
        }

        [Test]
        public void GameCanTakeGuess()
        {
            game.GetGuess("a");
            Assert.AreEqual("a", game.Guess);
        }

        [Test]
        public void GameChecksGuessNotNull()
        {
            guess = null;
            game.GetGuess(guess);
            var error = Assert.Throws<ArgumentException>(() => game.CheckGuess());
            Assert.That(error.Message, Is.EqualTo("Please enter a letter to guess!"));
        }

        [Test]
        public void CheckGameUpdatesAnswer()
        {
            game.GenerateAnswer();
            guess = "e";
            game.GetGuess(guess);
            game.CheckGuess();
            game.UpdateAnswer();
            Assert.AreEqual("_e__", game.Answer);
        }

        [Test]
        public void CheckGameUpdatesAnswerWithMultipleLetters()
        {
            game.GenerateAnswer();
            guess = "t";
            game.GetGuess(guess);
            game.CheckGuess();
            game.UpdateAnswer();
            Console.WriteLine(game.Answer);
            Assert.AreEqual("t__t", game.Answer);
        }

        [Test]
        public void GameChecksGuessNotAlreadyGuessed()
        {
            guess = "x";
            game.GetGuess(guess);
            game.CheckGuess();
            guess = "x";
            game.GetGuess(guess);
            var error = Assert.Throws<ArgumentException>(() => game.CheckGuess());
            Assert.That(error.Message, Is.EqualTo("That letter has already been guessed!"));
        }

        

        [Test]
        public void GameChecksGuessNotEmpty()
        {
            game.GetGuess(guess);
            var error = Assert.Throws<ArgumentException>(() => game.CheckGuess());
            Assert.That(error.Message, Is.EqualTo("Please enter a letter to guess!"));
        }

        [Test]
        public void GameChecksGuessNotBlankString()
        {
            guess = " ";
            game.GetGuess(guess);
            var error = Assert.Throws<ArgumentException>(() => game.CheckGuess());
            Assert.That(error.Message, Is.EqualTo("Please enter a letter to guess!"));
        }

        [Test]
        public void GameChecksIfLetterGuessedIsInWord()
        {
            int a = game.CorrectlyGuessed.Count;
            game.GetGuess("s");
            game.CheckGuess();
            Assert.AreEqual(a + 1, game.CorrectlyGuessed.Count);
        }

        [Test]
        public void GameDoesNotAddCorrectGuessToIncorrectGuessList()
        {
            int a = game.IncorrectlyGuessed.Count;
            game.GetGuess("s");
            game.CheckGuess();
            Assert.AreEqual(a, game.IncorrectlyGuessed.Count);
        }

        [Test]
        public void GameChecksIfLetterGuessedIsNotInWord()
        {
            int a = game.IncorrectlyGuessed.Count;
            game.GetGuess("r");
            game.CheckGuess();
            Assert.AreEqual(a + 1, game.IncorrectlyGuessed.Count);
        }

        [Test]
        public void GameDoesNotAddIncorrectGuessToCorrectList()
        {
            int a = game.CorrectlyGuessed.Count;
            game.GetGuess("q");
            game.CheckGuess();
            Assert.AreEqual(a, game.CorrectlyGuessed.Count);
        }
    }
}