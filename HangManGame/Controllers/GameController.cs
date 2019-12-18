using System.Diagnostics;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using HangManGame.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;

namespace HangManGame.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            //initialise a game object
            Game game = new Game();
            game.GetWord("testing");
            game.GenerateAnswer();
            game.GetGuess("t");
            //set in the session object
            string gameJson = JsonConvert.SerializeObject(game);
            HttpContext.Session.SetString("game", gameJson);
            return View("Test");
        }

        public IActionResult InPlay(Game game)
        {
            
            return View("Index", game);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult gamePlay()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult SubmitGuess(Game game)
        {
            // Add logic so it only does this when the guess is correct
            game.CorrectlyGuessed.Add(game.Guess);
            game.GetWord("easy");

            return RedirectToAction("InPlay", game);  /// was redirect to action 
            


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

