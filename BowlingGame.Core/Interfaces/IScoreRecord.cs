using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame.Core.Interfaces
{
    public interface IScoreRecord
    {
        int ScoreFrame { get; set; }
        int Score { get; set; }
    }
}
