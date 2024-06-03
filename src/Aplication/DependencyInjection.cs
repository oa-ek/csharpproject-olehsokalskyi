using Application.Abstractions;
using Application.Extentios;
using Application.Service;
using Application.Untils;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<UserManagerService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPublisherService, PublisherService>();
            services.AddScoped<IDeveloperService, DeveloperService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IPlatformService, PlatformService>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IAchievementService, AchievementService>();
            services.AddScoped<IAchievementUserService, AchievementUserService>();
            services.AddScoped<IRatingService, RatingService>();
            services.AddScoped<IGameTimeService, GameTimeService>();
            return services;
        }
    }
}
