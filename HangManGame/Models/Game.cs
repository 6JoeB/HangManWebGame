using System;
namespace HangManGame.Models
{
    public class Game
    {
        public string Word { get; set; }
        public string[] LettersAvailable = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        public string[] LettersCorrectlyGuessed = { };
        public string[] LettersIncorrectlyGuessed = { };
    }
}
