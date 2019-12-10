using System;
using System.Collections.Generic;
using System.Linq;

namespace HangManGame.Models

{
    public class Game
    {
        public string Word { get; set; }
        List<string> LettersAvailable = new List<string>(new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" });
        List<string> CorrectlyGuessed = new List<string>(new string[] { });
        List<string> IncorrectlyGuessed = new List<string>(new string[] { });
        public int NumberOfGuesses;
        public string Guess { get; set; }
        public bool win;

        public void GetGuess(string guess)
        {
            Guess = guess;
        }

        public void CheckGuess(string guess)
        {
            var splitWord = Word.Split(new string[] { "" }, StringSplitOptions.None);

            if (guess != null) //guess cannot be empty
            {
                if ((!CorrectlyGuessed.Contains(guess)) || (!IncorrectlyGuessed.Contains(guess))) //checks if guess has already been guessed
                {
                    NumberOfGuesses += 1;
                    if (splitWord.Contains(Guess)) //checking if word has letter being guessed
                        {
                        int index = 
                        CorrectlyGuessed.Insert(index, guess);
                        }
                    else if (Word.Contains(guess)) //checking if word guessed is secret word
                        {
                        win = true;
                        }
                    else //if guess is not correct
                        {
                        IncorrectlyGuessed.Append(guess);
                        }
                        
                }
            }
            else {
                Console.WriteLine("Please enter valid guess");
            }

        }

    }
}
