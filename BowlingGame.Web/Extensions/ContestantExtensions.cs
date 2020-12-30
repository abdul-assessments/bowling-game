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
        public static void Roll(this IContestant<FrameData> contestant, int pins)
        {
            bool hasPreviousFrame = contestant.ScoringData.Any();

            if (!hasPreviousFrame)
            {
                contestant.ScoringData.Add(new FrameData { Frame = 1, PinsKnocked = pins });
            }
            else
            {
                IEnumerable<FrameData> previousFrame = contestant.ScoringData.GroupBy(x => x.Frame).Last().AsEnumerable();
                int previousFrameNumber = previousFrame.First().Frame;

                //check if bonus round
                bool previousFrameComplete = previousFrameNumber < 10
                    ? previousFrame.Sum(x => x.PinsKnocked) == 10 || previousFrame.Count() == 2
                    : false;

                if (!previousFrameComplete)
                {
                    contestant.IsInstanceComplete = previousFrameNumber == 10 && previousFrame.Count() == 1 && previousFrame.Sum(x => x.PinsKnocked) + pins < 10 ||
                                                     previousFrameNumber == 10 && previousFrame.Count() == 2;
                    contestant.ScoringData.Add(new FrameData { Frame = previousFrameNumber, PinsKnocked = pins });
                }
                else
                {
                    contestant.ScoringData.Add(new FrameData { Frame = previousFrameNumber + 1, PinsKnocked = pins });
                }
            }
        }
    }
}
