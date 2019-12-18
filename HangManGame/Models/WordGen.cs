using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HangManGame.Models
{
    public class wordGenerator
    {
        public static string TextFileWordGetter()
        {
            OperatingSystem os = Environment.OSVersion;
            PlatformID pid = os.Platform;
            switch (pid)
            {
                case PlatformID.Win32NT:
                    string[] lines = File.ReadAllLines(@"..\..\..\..\HangManTextFiles\wordsOne.txt");
                    string word = lines[new Random().Next(lines.Length)];
                    return word;
                default:
                    string[] linesMac = File.ReadAllLines(@"../../../HangManWebGame/HangManWebGame/HangManTextFiles/wordsOne.txt");
                    string wordMac = linesMac[new Random().Next(linesMac.Length)];
                    return wordMac;
            }
            // Macintosh HD⁩ ▸ ⁨Users⁩ ▸ ⁨Student⁩ ▸ ⁨Desktop⁩ ▸ ⁨HangManGame⁩ ▸ ⁨HangManWebGame⁩ ▸ ⁨HangManWebGame⁩ ▸ ⁨HangManTextFiles⁩
        }
    }
}