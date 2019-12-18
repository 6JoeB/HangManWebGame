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
        Game game = new Game();
        public IActionResult Index()
        {

            //initialize game
            game.GetWord("testing");
            game.GenerateAnswer();
            Console.WriteLine("??????????");
            Console.WriteLine(game.Temp());
           
            return View("Index", game);
        }

        public IActionResult InPlay(Game game)
        {
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
          
          
            // Add logic so it only does this when the guess is correct

            //Get the guess from the form
            game.GetGuess(guess);
            Console.WriteLine("************");
            Console.WriteLine(game.Temp());

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

