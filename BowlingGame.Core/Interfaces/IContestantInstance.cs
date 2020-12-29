using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame.Core.Interfaces
{
    public interface IContestantInstance
    {
        string ContestantName { get; set; }
        bool IsInstanceComplete { get; }
        int GetScore();
        void Roll(int pins);
    }
}
