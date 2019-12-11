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
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            HttpContext.Session.SetString("test", "this is a session test");
            return View();
        }

        public IActionResult Profile()
        {
            ViewData["Message"] = "Your Profile page.";
            HttpContext.Session.GetString("test");


            return View();
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
        public IActionResult saveUsername([FromForm] string username
            )
        {
            return "Happy code is happy!"; 
           /* try
            {
                if (string.IsNullOrEmpty(username))
                {
                    throw new Exception();
                }
            }*/ 
        }
    }
}
        
    

