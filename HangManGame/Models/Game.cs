using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;

namespace HangManGame.Models

{
    public class Game
    {
        public string Word { get; set; }
        List<string> LettersAvailable = new List<string>(new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" });
        List<string> CorrectlyGuessed = new List<string>();
        List<string> IncorrectlyGuessed = new List<string>();
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
            var splitWord = Word.Split(new string[] { "" }, StringSplitOptions.None);

            if (Guess != null) //guess cannot be empty
            {
                if ((!CorrectlyGuessed.Contains(Guess)) || (!IncorrectlyGuessed.Contains(Guess))) //checks if guess has already been guessed
                {
                    if (splitWord.Contains(Guess)) //checking if word has letter being guessed
                        { 
                            for(int i = 0; i < splitWord.Length; i++)
                            {
                                if(splitWord[i] == Guess)
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
            else {
                Console.WriteLine("Please enter valid guess");
            }

        }

    }
}
