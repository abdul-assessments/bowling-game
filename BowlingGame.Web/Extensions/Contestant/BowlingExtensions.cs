using BowlingGame.Core.Interfaces;
using BowlingGame.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingGame.Web.Extensions.Contestant
{
    public static class BowlingExtensions
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

                if (previousFrameNumber == 10)
                    //check if max rounds
                    previousFrameComplete = previousFrame.Count() == 2 || previousFrameComplete;

                if (!previousFrameComplete)
                {
                    contestant.ScoringData.Add(new FrameData { Frame = previousFrameNumber, PinsKnocked = pins });
                    contestant.IsInstanceComplete = previousFrameComplete && previousFrame.Count() == 3;
                }
                else if (!contestant.IsInstanceComplete)
                {
                    contestant.ScoringData.Add(new FrameData { Frame = previousFrameNumber + 1, PinsKnocked = pins });
                }
            }
        }
    }
}
