using BowlingGame.Core.Interfaces;
using BowlingGame.Web.DataModels;
using BowlingGame.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingGame.Web.Extensions
{
    public static class ContestExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contest"></param>
        /// <param name="rollInput"></param>
        /// <returns>bool: if contestant is finished playing</returns>
        public static bool Roll(this IContest<FrameData> contest, Roll rollInput)
        {
            BowlingContestant contestant = contest.GetContestants<BowlingContestant>()
                                                    .FirstOrDefault(x => x.ContestantName == rollInput.ContestantName);
            contestant.Roll(rollInput.PinsKnocked);
            return contestant.IsInstanceComplete;
        }

        public static IEnumerable<LeaderboardData> GetLeaderboard(this IContest<FrameData> contest)
        {
            return contest.GetContestants<BowlingContestant>().Select(x => new LeaderboardData { ContestantName = x.ContestantName, Score = x.GetScore() });
        }
    }
}
