using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.Internal;

namespace HangManGame.Models

{
    public class Game
    {
        public string Word { get; set; }
        public string Answer;
        public List<string> LettersAvailable = new List<string>(new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" });
        public List<string> CorrectlyGuessed { get; set; }
        public List<string> IncorrectlyGuessed { get; set; }
        public int NumberOfGuesses;
        public string Guess { get; set; }
        public bool Win;
        public bool Lose;
        public int MatchingIndex;
        public int Index;

        public Game()
        {
            CorrectlyGuessed = new List<string>();
            IncorrectlyGuessed = new List<string>();
        }
 
        public void GetWord()
        //Gets word that player will be guessing
        {
            Word = wordGenerator.TextFileWordGetter();
        }

        public void SetDifficulty(string difficulty)
        {
            switch (difficulty)
            {
                case "hard":
                    NumberOfGuesses = 5;
                    break;
                case "medium":
                    NumberOfGuesses = 10;
                    break;
                case "easy":
                    NumberOfGuesses = 15;
                    break;
            }
        }

        public void GetGuess(string guess)
        //Gets letter that player is guessing is in the word

        {
            Guess = guess;
        }
 
        public void GenerateAnswer()
        //Creates string of dashes the same length as the word
        {
            StringBuilder answerBuilder = new StringBuilder();
            for (int i = 0; i < Word.Length; i++)
            {
                answerBuilder.Append("_");
            }
            Answer = answerBuilder.ToString();
        }
 
        public void UpdateAnswer()
        //Updates answer after a correct guess
        {
           
            int i = Word.IndexOf(Guess);
            StringBuilder answerUpdater = new StringBuilder(Answer);
            while (i != -1)
            {
                answerUpdater[i] = Guess[0];
                Answer = answerUpdater.ToString();
                i = Word.IndexOf(Guess, i + 1);
            }
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
                        if (Word.Contains(Guess))
                        //Adds letter to the correctly or incorrectly guessed list as needed
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
 
        public void CheckIfWon()
        //checks if the word has been fully guessed
        {
            if(Word == Answer)
            {
                Win = true;
            }
        }

        public void ReduceNumberOfGuesses()
        //reduces number of guesses left after a guess
        {
            NumberOfGuesses -= 1;
        }

        public void GameOver()
        //checks if player has lost
        {
            if (Word != Answer) {
                if (NumberOfGuesses == 0)
                {
                    Lose = true;
                } 
            }
        }

        public void StartGame()
        //sets up the parameters required to play a game
        {
            GetWord();
            SetDifficulty("medium");
            GenerateAnswer();
        }

        public void TakeTurn()
        //runs all the methods in order to take a turn
        {
            GetGuess(Guess);
            CheckGuess();
            UpdateAnswer();
            CheckIfWon();
            ReduceNumberOfGuesses();
            GameOver();
        }
    }
}