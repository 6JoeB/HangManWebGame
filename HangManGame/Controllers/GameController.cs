using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HangManGame.Models;
using Microsoft.AspNetCore.Http;



namespace HangManGame.Controllers
{
    public class GameController : Controller
    {

      /*  public IActionResult Index()
        {

            HttpContext.Session.SetString("guess", game.Guess);

            string guess = HttpContext.Session.GetString("Guess");
            Console.WriteLine(guess);
            Console.WriteLine("548375384578346578346578345349");

            return View("Index");
        }*/ 

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult gamePlay()
        {
            return View();
        }

        public string TestHello()
        {
            return "Hello";
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        


        [HttpPost]
        public IActionResult Index(Game game)
        {

            string CorrectlyGuessedLetters = String.Join("", game.CorrectlyGuessed.ToArray());
            

            HttpContext.Session.SetString("guess", game.Guess);
            HttpContext.Session.SetInt32("remainingGuesses", game.NumberOfGuesses);
            HttpContext.Session.SetString ("correctlyGuessed", CorrectlyGuessedLetters);
            HttpContext.Session.SetString("guess", game.Guess);
            HttpContext.Session.SetString("guess", game.Guess);
            HttpContext.Session.SetString("guess", game.Guess);
            return Redirect("https://localhost:44326/Game/Index");  /// was redirect to action 
            


        }

    }
}
/*
Guesses Ramaining
Correctly Guessed Letters _ _ _ _
Letters Available
Incorrect Guesses
Win or Loose messege
whats being set/ read out 
*/ 

