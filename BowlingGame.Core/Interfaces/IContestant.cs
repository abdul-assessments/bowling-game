using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame.Core.Interfaces
{
    public interface IContestant<ScoringDataType>
    {
        string ContestantName { get; set; }
        List<ScoringDataType> ScoringData { get; set; }
        bool IsInstanceComplete { get; set; }
        int GetScore();
    }
}
