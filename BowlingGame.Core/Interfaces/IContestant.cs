using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame.Core.Interfaces
{
    public interface IContestant
    {
        string ContestantName { get; set; }
        List<IScoreRecord> ScoringData { get; set; }
        bool IsInstanceComplete { get; set; }
        int GetScore();
    }
}
