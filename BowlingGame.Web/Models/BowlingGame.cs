using BowlingGame.Core.Interfaces;
using BowlingGame.Web.DataModels;
using BowlingGame.Web.Extensions;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingGame.Web.Models
{
    public class BowlingGame : IContest
    {
        public List<IContestant> Contestants { get; set; }

        public BowlingGame()
        {
            Contestants = new List<IContestant>();
        }
    }
}
