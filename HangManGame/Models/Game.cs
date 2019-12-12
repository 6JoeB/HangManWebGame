using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;

namespace HangManGame.Models

{
    public class Game
    {
        public string Word { get; set; }
        public List<string> LettersAvailable = new List<string>(new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" });
        public List<string> CorrectlyGuessed = new List<string>();
        public List<string> IncorrectlyGuessed = new List<string>();
        public int NumberOfGuesses;
        public string Guess { get; set; }
        public bool Win;
        public int MatchingIndex;
        public int Index;

        public void GetGuess(string guess)
        {
            Guess = guess;
        }

        public void GetWord(string word)
        {
            Word = word;
        }

        public void CheckGuess()
        {
            CorrectlyGuessed.Add(Guess);
        }
    }
}

        /*public bool CheckGuess()
        {
            var splitWord = Word.Split(new string[] { "" }, StringSplitOptions.None);

            if (!string.IsNullOrWhiteSpace(Guess)) //guess cannot be empty or a space
            {
                if ((!CorrectlyGuessed.Contains(Guess)) || (!IncorrectlyGuessed.Contains(Guess))) //checks if guess has already been guessed
                {
                    if (splitWord.Contains(Guess)) //checking if word or letter being guessed has letter being guessed
                    {
                        for (int i = 0; i < splitWord.Length; i++)
                        {
                            if (splitWord[i] == Guess)
                            {
                                CorrectlyGuessed[i] = Guess;
                            }
                        }
                    }
                    else if (Word.Contains(Guess)) //checking if word guessed is secret word
                    {
                        Win = true;
                    }
                    else //if guess is not correct
                    {
                        NumberOfGuesses += 1;
                        IncorrectlyGuessed.Append(Guess);
                    }

                }
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}*/
