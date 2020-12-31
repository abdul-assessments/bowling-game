using BowlingGame.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingGame.Web.DataModels
{
    public class FrameData : IScoreRecord
    {
        public int ScoreFrame { get; set; }
        public int Score { get; set; }
    }
}
