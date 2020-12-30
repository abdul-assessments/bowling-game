using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame.Core.Interfaces
{
    public interface ICachedContest
    {
        bool DoesCachedGameExist { get; }
        void CacheData<ScoringDataType>(IContestant<ScoringDataType>);
    }
}
