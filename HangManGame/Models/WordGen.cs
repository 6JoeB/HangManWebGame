using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HangManGame.Models
{
    public class wordGenerator
    {
        public static string RandomWordGetter()
        {
            string[] words = { "red", "green", "blue", "purple", "pink" };
            Random rand = new Random();
            int index = rand.Next(words.Length);
            return words[index];
        }

        public static string TextFileWordGetter()
        {
            string[] lines = File.ReadAllLines(@"..\..\..\..\HangManTextFiles\wordsOne.txt");
            string word = lines[new Random().Next(lines.Length)];
            return word;
        }
    }
}