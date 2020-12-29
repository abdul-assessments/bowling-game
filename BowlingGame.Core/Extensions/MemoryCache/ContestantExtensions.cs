using BowlingGame.Core.Classes;
using BowlingGame.Core.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame.Core.Extensions.MemoryCache
{
    public static class ContestantExtensions
    {
        public static List<T> GetContestants<T>(this IMemoryCache cache) where T : IContestant
        {
            return cache.Get<List<T>>("Contestants") ?? new List<T>();
        }

        public static void SaveContestants<T>(this IMemoryCache cache, List<T> contestantList) where T : IContestant
        {
            cache.Set("Contestants", contestantList);
        }
    }
}
