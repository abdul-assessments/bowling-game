using BowlingGame.Core.Interfaces;
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
        private ICachedContest _cachedGame;
        public BowlingController(ICachedContest cachedGame)
        {
            _cachedGame = cachedGame;
        }


        [HttpPost]
        [Route("roll")]
        public void Roll(int pinsKnocked, string contestant)
        {
            
        }

    }
}
