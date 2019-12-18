﻿using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using HangManGame.Models;
using System.Collections.Generic;
using System.Linq;

namespace HangManTests
{
    class GamePlayModelTests
    {
        Game game;

        string word = "test";
        string answer = "";
        List<string> lettersAvailable = new List<string>(new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" });
        List<string> correctlyGuessed = new List<string>();
        List<string> incorrectlyGuessed = new List<string>();
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
                Guess = guess
            };
            game.CorrectlyGuessed.Clear();
            game.IncorrectlyGuessed.Clear();
        }

        /*[Test]
        public void CanStartNewGame()
        {
            game.StartGame();
            Assert.AreEqual(10, game.NumberOfGuesses);
            Assert.IsInstanceOf(typeof(string), game.Word);
            Assert.AreEqual(game.Answer.Length, game.Word.Length);
        }*/

        [Test]
        public void GameCarriesOutGameLogicForATurn()
        {
            int a = game.NumberOfGuesses;
            int b = game.CorrectlyGuessed.Count;
            game.GenerateAnswer();
            game.Guess = "e";
            game.TakeTurn();
            Assert.AreEqual("_e__", game.Answer);
            Assert.AreEqual(false, game.Win);
            Assert.AreEqual(false, game.Lose);
            Assert.AreEqual(a - 1, game.NumberOfGuesses);
            Assert.AreEqual(b + 1, game.CorrectlyGuessed.Count);
        }

        [Test]
        public void GameCanUpdateAnswerOverMultipleTurns()
        {
            game.GenerateAnswer();
            game.Guess = "e";
            game.TakeTurn();
            game.Guess = "s";
            game.TakeTurn();
            game.Guess = "t";
            game.TakeTurn();
            Assert.AreEqual("test", game.Answer);
        }
    }
}