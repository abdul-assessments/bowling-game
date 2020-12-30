using BowlingGame.Core.Interfaces;
using BowlingGame.Web.DataModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingGame.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBowlingGameDependencies(this IServiceCollection services)
        {
            //Dependency registration for concrete class BowlingGame
            services.AddSingleton<Models.BowlingGame>();

            //register singleton BowlingGame as multiple services. The use of GetRequiredService does add a little extra weight when singleton is instantiated, however is a far more elegant solution using native .net core injection
            services.AddSingleton<ICachedContest>(x => x.GetRequiredService<Models.BowlingGame>());
            services.AddSingleton<IContest<FrameData>>(x => x.GetRequiredService<Models.BowlingGame>());

            return services;
        }
    }
}
