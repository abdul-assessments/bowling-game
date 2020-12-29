using Microsoft.Extensions.Caching.Memory;
using BowlingGame.Core.Extensions.MemoryCache;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BowlingGame.Core.Interfaces;

namespace BowlingGame.Core.Classes
{
    public class BowlingGame : ICachedGame
    {
        private List<IContestantInstance> _contestants;
        private bool _doesGamingSessionExist;
        private bool _isGamingSessionComplete;

        public bool DoesGamingSessionExist => _doesGamingSessionExist;
        public bool IsGamingSessionComplete => _doesGamingSessionExist;

        public BowlingGame(IMemoryCache _cache)
        {
            _contestants = _cache.GetContestants();
            _doesGamingSessionExist = _contestants.Any();
            _isGamingSessionComplete = _doesGamingSessionExist ? !_contestants.Any(x => !x.IsInstanceComplete) : false;
        }
    }
}
