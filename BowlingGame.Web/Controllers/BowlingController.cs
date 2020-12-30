using BowlingGame.Core.Interfaces;
using BowlingGame.Web.Extensions;
using BowlingGame.Web.DataModels;
using BowlingGame.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingGame.Web.Controllers
{
    [Route("api/bowling")]
    [ApiController]
    public class BowlingController : ControllerBase
    {
        private IContest<FrameData> _bowlingGame;
        public BowlingController(IContest<FrameData> bowlingGame)
        {
            _bowlingGame = bowlingGame;
        }


        [HttpPost]
        [Route("roll")]
        public bool Roll(Roll rollInput)
        {
            return _bowlingGame.Roll(rollInput);
        }        

        [HttpPost]
        [Route("addcontestant")]
        public void AddContestant(Contestant contestant)
        {

        }

        [HttpGet]
        [Route("leaderboard")]
        public IEnumerable<LeaderboardData> Leaderboard()
        {
            return _bowlingGame.GetLeaderboard();
        }

        [HttpGet]
        [Route("reset")]
        public void ResetGame()
        {

        }
    }
}
