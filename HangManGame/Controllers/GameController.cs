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

        public IActionResult Index()
        {
            return View("Index");
        }

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
            return RedirectToRoute("Game");  /// was redirect to action 

        }

    }
}
/*
Guesses Ramaining
Correctly Guessed Letters _ _ _ _
Letters Available
Incorrect Guesses
Win or Loose messege
*/ 

