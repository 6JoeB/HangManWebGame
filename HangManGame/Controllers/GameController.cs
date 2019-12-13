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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost]
        public IActionResult Index(Game game)
        {
            HttpContext.Session.SetString("Guess", game.Guess);
            return RedirectToAction("Game");
        }

    }
}



