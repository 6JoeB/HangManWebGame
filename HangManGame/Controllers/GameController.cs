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
        //Create instance of the game
        private static Game game = new Game();
  
        public IActionResult Index()
        {

            //Initialise the game
            game.GetWord("testing");
            game.GenerateAnswer();

            return View("Index", game);
        }

        public IActionResult InPlay()
        {
            game.UpdateAnswer();
            //Display the current state of the game
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
        public IActionResult SubmitGuess([FromForm] string guess)
        {

            
            //Update the game based on the guess
            game.GetGuess(guess);
            game.CheckGuess();
            game.UpdateAnswer();
            game.CheckIfWon();
            game.GameOver(); 
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

