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
        public static bool Roll(this IContest contest, Roll rollInput)
        {
            IContestant contestant = contest.Contestants.FirstOrDefault(x => x.ContestantName == rollInput.ContestantName);
            contestant.Roll(rollInput.PinsKnocked);
            return contestant.IsInstanceComplete;
        }

        public static IEnumerable<LeaderboardData> GetLeaderboard(this IContest contest)
        {
            return contest.Contestants.Select(x => new LeaderboardData { ContestantName = x.ContestantName, Score = x.GetScore() });
        }

        public static void Reset(this IContest contest)
        {
            contest.Contestants = new List<IContestant>();
        }

        public static bool IsGameComplete(this IContest contest)
        {
            return !contest.Contestants.Any(x => !x.IsInstanceComplete);
        }
    }
}
