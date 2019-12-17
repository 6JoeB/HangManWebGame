using System;
using System.Collections.Generic;

namespace HangManGame.Logic
{
    public class GuessResult
    {
        public GuessResult(bool hasWon, bool hasLost, List<char> correctGuesses, List<char> incorrectGuesses, int livesRemaining)
        {
            HasWon = hasWon;
            HasLost = hasLost;
            CorrectGuesses = correctGuesses;
            IncorrectGuesses = incorrectGuesses;
            LivesRemaining = livesRemaining;
        }

        public bool HasWon { get; private set; }
        public bool HasLost { get; private set; }

        public List<char> CorrectGuesses { get; private set; }
        public List<char> IncorrectGuesses { get; private set; }
        public int LivesRemaining { get; private set; }
    }
}
