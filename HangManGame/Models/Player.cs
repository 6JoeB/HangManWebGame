using System;
namespace HangManGame.Models
{
    public class Player
    {
        public string Name { get; set; }

        public static Player Register(string name)
        {
            return new Player
            {
                Name = name
            };
        }
    }
}
