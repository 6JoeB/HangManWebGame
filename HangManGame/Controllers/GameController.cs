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
        Game game = new Game();
        public IActionResult Index()
        {
            //initialize game
            
            game.GetWord("testing");
            game.GenerateAnswer();
            
            //string gameJson = JsonConvert.SerializeObject(game);
            //HttpContext.Session.SetString("game", gameJson);

            //HttpContext.Session.Get("game");
            //Game gameSession = JsonConvert.DeserializeObject<Game>(gameJson);
            //gameSession.UpdateAnswer();
            //Console.WriteLine(gameSession.Answer);
            //Console.WriteLine(gameSession.Word);
            //Console.WriteLine(gameSession.NumberOfGuesses);

            return View("Index", game);
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
        public IActionResult SubmitGuess(Game g)
        {
            Console.WriteLine("************");
            Console.WriteLine(g.Guess);
            Console.WriteLine(g);
            // Add logic so it only does this when the guess is correct
            game.CorrectlyGuessed.Add(g.Guess);
 
            //game.GetGuess(g.Guess);


            game.GetGuess("t");
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

