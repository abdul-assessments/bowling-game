using BowlingGame.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingGame.Web.Models
{
    public class BowlingContestant : IContestant
    {
        private List<FrameData> _scoringData;
        private bool _isInstanceComplete;
        public bool IsInstanceComplete => _isInstanceComplete;
        public string ContestantName { get; set; }

        public BowlingContestant()
        {
            _scoringData = new List<FrameData>();
        }

        public int GetScore()
        {
            int totalScore = 0;
            //calculate score for frames 1-9
            foreach (var group in _scoringData.Where(x => x.Frame != 10).GroupBy(x => x.Frame))
            {
                int frameScore = 0;
                int frameNumber = group.Key;
                IEnumerable<FrameData> currentFrame = group.AsEnumerable();

                //its a strike
                if (currentFrame.Count() == 1 && currentFrame.Sum(x => x.PinsKnocked) == 10)
                {
                    FrameData frame = currentFrame.Last();
                    int index = _scoringData.LastIndexOf(frame);
                    frameScore = 10 + _scoringData[index + 1].PinsKnocked + _scoringData[index + 2].PinsKnocked;
                }
                else if (currentFrame.Count() == 2 && currentFrame.Sum(x => x.PinsKnocked) == 10)
                {
                    FrameData frame = currentFrame.Last();
                    int index = _scoringData.LastIndexOf(frame);
                    frameScore = 10 + _scoringData[index + 1].PinsKnocked;
                }
                else
                {
                    frameScore = currentFrame.Sum(x => x.PinsKnocked);
                }

                totalScore += frameScore;
            }

            //add 10th frame
            totalScore += _scoringData.Where(x => x.Frame == 10).Sum(x => x.PinsKnocked);

            return totalScore;
        }

        public void Roll(int pins)
        {
            bool hasPreviousFrame = _scoringData.Any();

            if (!hasPreviousFrame)
            {
                _scoringData.Add(new FrameData { Frame = 1, PinsKnocked = pins });
            }
            else
            {
                IEnumerable<FrameData> previousFrame = _scoringData.GroupBy(x => x.Frame).Last().AsEnumerable();
                int previousFrameNumber = previousFrame.First().Frame;

                //check if bonus round
                bool previousFrameComplete = previousFrameNumber < 10
                    ? previousFrame.Sum(x => x.PinsKnocked) == 10 || previousFrame.Count() == 2
                    : false;
                
                if (previousFrameNumber == 10)
                    //check if max rounds
                    previousFrameComplete = previousFrame.Count() == 3 || previousFrameComplete;
                
                if (!previousFrameComplete)
                {
                    _scoringData.Add(new FrameData { Frame = previousFrameNumber, PinsKnocked = pins });
                    _isInstanceComplete = previousFrameComplete && previousFrame.Count() == 3;
                }
                else if (!_isInstanceComplete)
                {
                    _scoringData.Add(new FrameData { Frame = previousFrameNumber + 1, PinsKnocked = pins });
                }
            }
        }
    }
}
