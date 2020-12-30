using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame.Core.Interfaces
{
    public interface IContest<ScoringData>
    {
        bool IsContestComplete { get; }
        List<TContestant> GetContestants<TContestant>() where TContestant : IContestant<ScoringData>;
    }
}
