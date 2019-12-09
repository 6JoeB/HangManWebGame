using System;
using System.Linq;

namespace HangManGame.Models

{
    public class Game
    {
        public string Word { get; set; }
        public string[] LettersAvailable = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        public string[] LettersCorrectlyGuessed = { };
        public string[] LettersIncorrectlyGuessed = { };
        public int NumberOfGuesses;
        public string Guess { get; set; }

        public void GetGuess(string guess)
        {
            Guess = guess;
        }

        public void CheckGuess(string guess)
        {
            var splitWord = Word.Split(new string[] { "" }, StringSplitOptions.None);

            if (guess != null)
            {
                if ((!LettersCorrectlyGuessed.Contains(guess)) || (!LettersIncorrectlyGuessed.Contains(guess)))
                { 
                    if (splitWord.Contains(Guess))
                        {
                        LettersCorrectlyGuessed.Append(guess);
                        }
                    else if (Word.Contains(guess))
                        {
                        
                        }
                    else
                        {
                        LettersIncorrectlyGuessed.Append(guess);
                        }
                        
                }
            }
            else {
                Console.WriteLine("Please enter valid guess");
            }

        }

    }
}
