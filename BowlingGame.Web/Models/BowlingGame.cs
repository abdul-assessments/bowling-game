using BowlingGame.Core.Interfaces;
using BowlingGame.Web.DataModels;
using BowlingGame.Web.Extensions;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingGame.Web.Models
{
    public class BowlingGame : ICachedContest, IContest<FrameData>
    {
        private bool _doesGamingSessionExist;
        private bool _isGamingSessionComplete;
        private IMemoryCache _cache;
        private List

        public bool DoesCachedGameExist => _doesGamingSessionExist;
        public bool IsContestComplete => _isGamingSessionComplete;

        public BowlingGame(IMemoryCache cache)
        {
            _cache = cache;
            _doesGamingSessionExist = _cache.GetContestants<IContestant<FrameData>>().Any();
            _isGamingSessionComplete = _doesGamingSessionExist ? !_cache.GetContestants<IContestant<FrameData>>().Any(x => !x.IsInstanceComplete) : false;
        }

        public List<T> GetContestants<T>() where T : IContestant<FrameData>
        {
            return _cache.GetContestants<T>().OrderBy(x => x.GetScore()).ToList();
        }

        public void CacheData()
        {
            throw new NotImplementedException();
        }
    }
}
