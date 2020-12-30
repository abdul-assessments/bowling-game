using BowlingGame.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingGame.Web.Models
{
    public class BowlingContestant : IContestant<FrameData>
    {
        public bool IsInstanceComplete { get; set; }
        public string ContestantName { get; set; }
        public List<FrameData> ScoringData { get; set; }

        public BowlingContestant()
        {
            ScoringData = new List<FrameData>();
        }

        public int GetScore()
        {
            int totalScore = 0;
            //calculate score for frames 1-9
            foreach (var group in ScoringData.Where(x => x.Frame != 10).GroupBy(x => x.Frame))
            {
                int frameScore = 0;
                int frameNumber = group.Key;
                IEnumerable<FrameData> currentFrame = group.AsEnumerable();

                //its a strike
                if (currentFrame.Count() == 1 && currentFrame.Sum(x => x.PinsKnocked) == 10)
                {
                    FrameData frame = currentFrame.Last();
                    int index = ScoringData.LastIndexOf(frame);
                    frameScore = 10 + ScoringData[index + 1].PinsKnocked + ScoringData[index + 2].PinsKnocked;
                }
                else if (currentFrame.Count() == 2 && currentFrame.Sum(x => x.PinsKnocked) == 10)
                {
                    FrameData frame = currentFrame.Last();
                    int index = ScoringData.LastIndexOf(frame);
                    frameScore = 10 + ScoringData[index + 1].PinsKnocked;
                }
                else
                {
                    frameScore = currentFrame.Sum(x => x.PinsKnocked);
                }

                totalScore += frameScore;
            }

            //add 10th frame
            totalScore += ScoringData.Where(x => x.Frame == 10).Sum(x => x.PinsKnocked);

            return totalScore;
        }
    }
}
