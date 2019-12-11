using HangManGame.Models;
using NUnit.Framework;

namespace HangManTests
{
    public class Tests
    {
        public Play play; 
        [SetUp]
        public void Setup()
        {
           play = new Play();
        }

        [Test]
        public void CheckForArray()
        {
            Assert.That(play.words, Is.Not.Empty);
        }
    }
}





/*

        [SetUp]
public void Setup()
{
    bankAccount = new BankAccount();
}
// Above setups up and makes bank account for each tests, like let. 

[Test]
public void BankAccount_HasBalance_Of0()
{
    //Arrange 
    //Act
    //Assert 
    Assert.That(bankAccount.Balance == 0);
}

*/