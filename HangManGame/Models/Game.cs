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

        public void GetWord(string word)
            //Gets word that player will be guessing
        {
            Word = word;
        }

        public void GetGuess(string guess)
        //Gets letter that player is guessing is in the word
        {
            Guess = guess;
        }

        public void CheckGuess()
            //Checks players guess has not already been guessed, and if it is correct or not
        {
            if (!string.IsNullOrWhiteSpace(Guess))
                //Throws error if no letter entered to guess
            {
                if (!CorrectlyGuessed.Contains(Guess))
                    //Checks letter guess is not already in the correctly guessed list
                {
                    if (!IncorrectlyGuessed.Contains(Guess))
                    //Checks letter guess is not already in the incorrectly guessed list
                    {
                        //Adds letter to the correctly or incorrectly guessed list as needed
                        if (Word.Contains(Guess))
                        {
                            CorrectlyGuessed.Add(Guess);
                        }
                        else
                        {
                            IncorrectlyGuessed.Add(Guess);
                        }
                    }
                    else
                    {
                        throw new ArgumentException("That letter has already been guessed!");
                    }
                }
                else
                {
                    throw new ArgumentException("That letter has already been guessed!");
                }
            }
            else
            {
                throw new ArgumentException("Please enter a letter to guess!");
            }
        }
    }
}


/*
            //test
            // _ _ _ _ 
            // Guess = 'e'
            // _ e _ _ 
}*/