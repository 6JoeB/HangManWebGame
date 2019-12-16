using System.Collections.Generic;
using System.Linq;

namespace HangManGame.Logic
{
    public class Game
    {
        public string Word { get; private set; }
        public Difficulty Difficulty { get; private set; }

        /// <summary>
        /// Values that should only be set when the game is started should be in the constructor
        /// </summary>
        public Game(string word, Difficulty difficulty = Difficulty.Easy)
        {
            Word = word;
            Difficulty = difficulty;
        }

        /// <summary>
        /// All of the logic to decide incorrect/correct guesses is self-contained
        /// No state is necessary (no need to hold onto lists of correct/incorrect guesses
        /// </summary>
        public GuessResult Guess(List<char> guesses)
        {
            var word = Word.ToCharArray().ToList();
            var correctGuesses = new List<char>();
            var incorrectGuesses = new List<char>();

            // Did we get ALL of the expected chars in our correct guesses?
            bool hasWon = true;
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
            
            foreach (var letter in word)
            {
                if (!guesses.Contains(letter))
                {
                    hasWon = false;
                    break;
                }
            }

            // Has our incorrect guess count exceeded our lives?
            int livesRemaining = (int)Difficulty - incorrectGuesses.Count;
            bool hasLost = livesRemaining <= 0;
            if (hasLost)
                hasWon = false;

            // return a guessResult to show if we won or lost!
            return new GuessResult(hasWon, hasLost, correctGuesses, incorrectGuesses, livesRemaining);
        }

    }
}