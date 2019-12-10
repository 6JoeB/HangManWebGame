using HangManGame.Models;
using NUnit.Framework;

namespace HangManTests
{
    public class Tests
    {
       
        public wordGenerator wordGenerator; 
        [SetUp]
        public void Setup()
        {
           wordGenerator = new wordGenerator();
        }

        [Test]
        public void CheckForArray()
        {
            Assert.That(wordGenerator.words, Is.Not.Empty);
        }

        [Test]
        public void CheckArrayContents()
        {
            Assert.AreEqual(wordGenerator.words[0], "red");
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