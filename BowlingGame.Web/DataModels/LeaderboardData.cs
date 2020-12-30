using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingGame.Web.DataModels
{
    public class LeaderboardData : Contestant
    {
        public int Score { get; set; }
    }
}
