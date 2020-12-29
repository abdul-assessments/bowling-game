using BowlingGame.Core.Classes;
using BowlingGame.Core.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame.Core.Extensions.MemoryCache
{
    public static class BowlingGameExtensions
    {
        public static List<IContestantInstance> GetContestants(this IMemoryCache cache)
        {
            return cache.Get<List<IContestantInstance>>("Contestants");
        }

        public static void SaveContestants(this IMemoryCache cache, List<IContestantInstance> contestantList)
        {
            cache.Set("Contestants", contestantList);
        }
    }
}
