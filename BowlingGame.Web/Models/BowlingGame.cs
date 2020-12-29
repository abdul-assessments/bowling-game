using BowlingGame.Core.Extensions.MemoryCache;
using BowlingGame.Core.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingGame.Web.Models
{
    public class BowlingGame : ICachedContest, IContest
    {
        private List<BowlingContestant> _contestants;
        private bool _doesGamingSessionExist;
        private bool _isGamingSessionComplete;

        public bool DoesCachedGameExist => _doesGamingSessionExist;
        public bool IsContestComplete => _isGamingSessionComplete;

        public BowlingGame(IMemoryCache _cache)
        {
            _contestants = _cache.GetContestants<BowlingContestant>();
            _doesGamingSessionExist = _contestants.Any();
            _isGamingSessionComplete = _doesGamingSessionExist ? !_contestants.Any(x => !x.IsInstanceComplete) : false;
        }
    }
}
