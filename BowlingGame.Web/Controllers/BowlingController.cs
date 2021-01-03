using BowlingGame.Core.Interfaces;
using BowlingGame.Web.Extensions;
using BowlingGame.Web.DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace BowlingGame.Web.Controllers
{
    [EnableCors("AngularBowlingGameIntegration")]
    [Route("api/bowling")]
    [ApiController]
    public class BowlingController : ControllerBase
    {
        private IContest _bowlingGame;
        public BowlingController(IContest bowlingGame)
        {
            _bowlingGame = bowlingGame;
        }


        [HttpPost]
        [Route("roll")]
        public IActionResult Roll(Roll rollInput)
        {
            if (_bowlingGame.Contestants.Any())
            {
                return Ok(_bowlingGame.Roll(rollInput));
            }
            else
            {
                return Ok();
            }
        }        

        [HttpPost]
        [Route("addcontestants")]
        public IActionResult AddContestants(List<Contestant> contestantList)
        {
            if (!_bowlingGame.Contestants.Any())
            {
                _bowlingGame.Contestants = contestantList
                                            .Select(x => new Models.BowlingContestant { ContestantName = x.ContestantName } )
                                            .Cast<IContestant>()
                                            .ToList();
                return Ok(true);
            }
            return Ok(false);
        }

        [HttpGet]
        [Route("leaderboard")]
        public IActionResult Leaderboard()
        {            
            return Ok(_bowlingGame.GetLeaderboard());
        }

        [HttpGet]
        [Route("hasexisting")]
        public IActionResult CheckExistingGame()
        {
            return Ok(_bowlingGame.Contestants.Any());
        }

        [HttpGet]
        [Route("getcontestants")]
        public IActionResult GetContestants()
        {
            return Ok(_bowlingGame.Contestants.Select(x => new { x.ContestantName, pinsLeft = x.PinsLeft() }));
        }

        [HttpGet]
        [Route("iscomplete")]
        public IActionResult CheckExistingGameIsComplete()
        {
            return Ok(!_bowlingGame.Contestants.Any() || _bowlingGame.IsGameComplete());
        }

        [HttpGet]
        [Route("reset")]
        public IActionResult ResetGame()
        {
            try
            {
                _bowlingGame.Contestants = new List<IContestant>();
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }            
        }
    }
}
