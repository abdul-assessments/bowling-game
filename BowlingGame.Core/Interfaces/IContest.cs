using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame.Core.Interfaces
{
    public interface IContest
    {
        bool IsContestComplete { get; }
        List<TContestant> GetLeaderboard<TContestant>() where TContestant : IContestant;
    }
}
