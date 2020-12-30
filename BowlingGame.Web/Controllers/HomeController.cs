using BowlingGame.Core.Interfaces;
using BowlingGame.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingGame.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICachedContest _cachedGame;
        public HomeController(ILogger<HomeController> logger, ICachedContest cachedGame)
        {
            _logger = logger;
            _cachedGame = cachedGame;
        }

        [Route("")]
        public IActionResult Index()
        {
            return View(_cachedGame);
        }

        [Route("privacy")]
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
