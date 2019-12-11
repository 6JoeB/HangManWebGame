using System;
using NUnit.Framework;
using HangManGame.Models;

namespace HangManTests

{
    [TestFixture]
    class PlayerModelTests
    {
        Player player;

        string name = "Steph Curry";

        [SetUp]
        public void Setup()
        {
            player = new Player
            {
                Name = name
            };
        }

        [Test]
        public void CreatesAnInstanceOfPlayer()
        {
            Assert.That(player, Is.InstanceOf<Player>());

        }

        [Test]
        public void PlayerHasName()
        {
            Assert.AreEqual(player.Name, name);
        }

        [Test]
        public void PlayerCanRegister()
        {
            Player newPlayer = Player.Register(name);
            Assert.That(newPlayer, Is.InstanceOf<Player>());
        }
    }
}
