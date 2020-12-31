using BowlingGame.Core.Interfaces;
using BowlingGame.Web.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingGame.Web.Extensions
{
    public static class ContestantExtensions
    {
        public static void Roll(this IContestant contestant, int pins)
        {
            bool hasPreviousFrame = contestant.ScoringData.Any();

            if (!hasPreviousFrame)
            {
                contestant.ScoringData.Add(new FrameData { ScoreFrame = 1, Score = pins });
            }
            else
            {
                IEnumerable<IScoreRecord> previousFrame = contestant.ScoringData.GroupBy(x => x.ScoreFrame).Last().AsEnumerable();
                int previousFrameNumber = previousFrame.First().ScoreFrame;

                //check if bonus round
                bool previousFrameComplete = previousFrameNumber < 10
                    ? previousFrame.Sum(x => x.Score) == 10 || previousFrame.Count() == 2
                    : false;

                if (!previousFrameComplete)
                {
                    contestant.IsInstanceComplete = previousFrameNumber == 10 && previousFrame.Count() == 1 && previousFrame.Sum(x => x.Score) + pins < 10 ||
                                                     previousFrameNumber == 10 && previousFrame.Count() == 2;
                    contestant.ScoringData.Add(new FrameData { ScoreFrame = previousFrameNumber, Score = pins });
                }
                else
                {
                    contestant.ScoringData.Add(new FrameData { ScoreFrame = previousFrameNumber + 1, Score = pins });
                }
            }
        }
    }
}
