using System;
using System.ComponentModel;

namespace HangManGame.Models
{
    public class Player
    {
        [DisplayName("UserName")]
        public string UserName { get; set; }

        public static Player Register(string username)
        {
            return new Player
            {
                UserName = username
            };
        }
    }
}
