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
            services.AddSingleton<IContest, Models.BowlingGame>();

            services.AddCors(options =>
            {
                options.AddPolicy("AngularBowlingGameIntegration",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            return services;
        }
    }
}
