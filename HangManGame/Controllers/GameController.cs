using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HangManGame.Models;
using Microsoft.AspNetCore.Http;
using HangManGame.Logic;

namespace HangManGame.Controllers
{
    public class GameController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            // Normally you would want to load / generate your word here
            string word = "easy";
            HttpContext.Session.SetString("word", word);
            var model = new Guesses(word);

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(Guesses model)
        {
            var word = HttpContext.Session.GetString("word");
            var game = new Game(word, Difficulty.Easy);

            var guesses = new List<char>(model.PreviousGuesses) { model.Guess.Value };
            var result = game.Guess(guesses);
            var viewResult = new Guesses(game.Word, model.Guess, result);

            return View(viewResult);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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

