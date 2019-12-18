using System;
using HangManGame.Logic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace HangManGame.Models
{
    public class Guesses
    {
        private readonly string word;

        private char[] allLetters = {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
        };

        public Guesses() { }
        public Guesses(string word)
        {
            this.word = word;
            LettersAvailable = allLetters.ToList();
        }

        public Guesses(string word, char? guess, GuessResult result)
        {
            this.word = word;
            Guess = guess;
            CorrectGuesses = result.CorrectGuesses;
            IncorrectGuesses = result.IncorrectGuesses;
            HasWon = result.HasWon;
            HasLost = result.HasLost;
            LivesRemaining = result.LivesRemaining;

            PreviousGuesses = new List<char>();
            PreviousGuesses.AddRange(IncorrectGuesses);
            PreviousGuesses.AddRange(CorrectGuesses);

            LettersAvailable = allLetters.Where(x =>
                    !PreviousGuesses.Contains(x)
                ).ToList(); // LINQ magic
        }

        [Required]
        public char? Guess { get; set; }
        public List<char> PreviousGuesses { get; set; } = new List<char>();

        public List<char> LettersAvailable { get; }
        public List<char> CorrectGuesses { get; } = new List<char>();
        public List<char> IncorrectGuesses { get; } = new List<char>();

        public bool HasWon { get; }
        public bool HasLost { get; }
        public int LivesRemaining { get; }

        public String OutputAnswer()
        {
            var answerBuilder = new StringBuilder();
            foreach (var letter in word.ToCharArray())
            {
                if (CorrectGuesses.Contains(letter))
                {
                    answerBuilder.Append(letter);
                }
                else
                {
                    answerBuilder.Append("_");
                }
                answerBuilder.Append(" ");
            }

            return answerBuilder.ToString();
        }
    
    }
}
