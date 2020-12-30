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
        private bool _doesGamingSessionExist;
        private bool _isGamingSessionComplete;
        private IMemoryCache _cache;

        public bool DoesCachedGameExist => _doesGamingSessionExist;
        public bool IsContestComplete => _isGamingSessionComplete;

        public BowlingGame(IMemoryCache cache)
        {
            _cache = cache;
            _doesGamingSessionExist = _cache.GetContestants<IContestant>().Any();
            _isGamingSessionComplete = _doesGamingSessionExist ? !_cache.GetContestants<IContestant>().Any(x => !x.IsInstanceComplete) : false;
        }

        public List<T> GetLeaderboard<T>() where T : IContestant
        {
            return _cache.GetContestants<T>().OrderBy(x => x.GetScore()).ToList();
        }
    }
}
