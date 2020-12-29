using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame.Core.Interfaces
{
    public interface IContestant
    {
        string ContestantName { get; set; }
        bool IsInstanceComplete { get; }
        int GetScore();
    }
}
