using BowlingGame.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingGame.Web.DataModels
{
    public class LeaderboardData : Contestant, IScoreRecord
    {
        public int Score { get; set; }
        public int ScoreFrame { get; set; }
    }
}
