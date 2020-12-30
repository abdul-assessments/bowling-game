using BowlingGame.Core.Interfaces;
using BowlingGame.Web.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingGame.Web.Extensions.ServiceCollection
{
    public static class BowlingExtensions
    {
        public static IServiceCollection AddBowlingGameDependencies(this IServiceCollection services)
        {
            //Dependency registration for concrete class BowlingGame
            services.AddSingleton<Models.BowlingGame>();

            //register as multiple services
            services.AddSingleton<ICachedContest>(x => x.GetRequiredService<Models.BowlingGame>());
            services.AddSingleton<IContest>(x => x.GetRequiredService<Models.BowlingGame>());
            return services;
        }
    }
}
