using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangManGame.Models
{
    public class wordGenerator
    {
        public static string randomWordGetter()
        {
            string[] words = { "red", "green", "blue", "purple", "pink" };
            Random rand = new Random();
            int index = rand.Next(words.Length);
            return words[index];
        }
    }
}
