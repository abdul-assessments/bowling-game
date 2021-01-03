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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contestant"></param>
        /// <param name="pins"></param>
        /// <returns>The max pins for next throw</returns>
        public static int Roll(this IContestant contestant, int pins)
        {
            bool hasPreviousFrame = contestant.ScoringData.Any();
            if (!hasPreviousFrame)
            {
                pins = pins >= 10 ? 10 : pins;
                contestant.ScoringData.Add(new FrameData { ScoreFrame = 1, Score = pins });
                return pins >= 10 ? 10 : 10 - pins;
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
                    return 10;
                }
                else
                {
                    pins = pins >= 10 ? 10 : pins;
                    contestant.ScoringData.Add(new FrameData { ScoreFrame = previousFrameNumber + 1, Score = pins });
                    return 10 - pins > 0 
                        ? 10 - pins
                        : 10;
                }                
            }
        }

        public static int GetLastScoredFrame(this IContestant contestant)
        {
            if (contestant.IsInstanceComplete)
                return 10;

            bool hasPreviousFrame = contestant.ScoringData.Any();

            if (!hasPreviousFrame)
            {
                return 0;
            }
            else
            {
                return contestant.ScoringData.Last().ScoreFrame;               
            }
        }

        public static int PinsLeft(this IContestant contestant)
        {
            if (contestant.IsInstanceComplete)
                return -1;

            bool hasPreviousFrame = contestant.ScoringData.Any();

            if (!hasPreviousFrame)
            {                
                return 10;
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
                    return 10 - previousFrame.Sum(x => x.Score);
                }
                else
                {                    
                    return 10;
                }
            }
        }
    }
}
