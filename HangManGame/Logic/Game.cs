using System;
using System.Collections.Generic;
using System.Linq;

namespace HangManGame.Logic
{
    public class Game
    {
        public string Word { get; private set; } //private set so that it cannot be changed in the url
        public Difficulty Difficulty { get; private set; }
        //values that should only be set when the game is started should be in the constructer

        public Game(string word, Difficulty difficulty = Difficulty.hard)
        {
            Word = word;
            Difficulty = difficulty;
        }

        public GuessResult Guess(List<char> guesses)
        {
            var word = Word.ToCharArray().ToList();
            var correctGuesses = new List<char>();
            var incorrectGuesses = new List<char>();

            foreach (var letter in guesses)
            {
                if (word.Contains(letter))
                {
                    correctGuesses.Add(letter);
                }
                else
                {
                    incorrectGuesses.Add(letter);
                }
            }

            bool hasWon = true;
            foreach (var letter in word)
            {
                if (!guesses.Contains(letter))
                {
                    hasWon = false;
                    break;
                }
            }

            int livesRemaining = (int)Difficulty - incorrectGuesses.Count;
            bool hasLost = livesRemaining <= 0;
            if (hasLost)
                hasWon = false;

            return new GuessResult(hasWon, hasLost, correctGuesses, incorrectGuesses, livesRemaining);
        }
    }
}
