
using GameLib.Core.Entities;
using GameLib.Repository.Repositories.Achievements;
using GameLib.Repository.Repositories.AchievementUsers;
using GameLib.Repository.Repositories.Developers;
using GameLib.Repository.Repositories.Games;
using GameLib.Repository.Repositories.GameTimes;
using GameLib.Repository.Repositories.Genres;
using GameLib.Repository.Repositories.Languages;
using GameLib.Repository.Repositories.Payments;
using GameLib.Repository.Repositories.Platforms;
using GameLib.Repository.Repositories.Publishers;
using GameLib.Repository.Repositories.Ratings;
using GameLib.Repository.Repositories.UserRole;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Repository
{
    public static class DependencyInjectionRepositories
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
           

           // services.AddScoped<IDiscountRepository, DiscountRepository>();
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IPlatformRepository, PlatformRepository>();
            services.AddScoped<IPublisherRepository, PublisherRepository>();
           // services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAchievementRepository, AchievementRepository>();
            services.AddScoped<IAchievementUserRepository, AchievementUserRepository>();
            services.AddScoped<IDeveloperRepository, DeveloperRepository>();
            services.AddScoped<IGameTimeRepository, GameTimeRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();
   

            ;
            //  services.AddScoped<IRoleRepository, RoleRepository>();



        }
    }
}
