using GameLib.Repository.Achievements;
using GameLib.Repository.AchievementUsers;
using GameLib.Repository.Developers;
using GameLib.Repository.Discounts;
using GameLib.Repository.Games;
using GameLib.Repository.GameTimes;
using GameLib.Repository.Genres;
using GameLib.Repository.Languages;
using GameLib.Repository.Payments;
using GameLib.Repository.Platforms;
using GameLib.Repository.Publishers;
using GameLib.Repository.Ratings;
using GameLib.Repository.Roles;
using GameLib.Repository.Users;
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
            services.AddScoped<IDiscountRepository, DiscountRepository>();
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IPlatformRepository, PlatformRepository>();
            services.AddScoped<IPublisherRepository, PublisherRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAchievementRepository, AchievementRepository>();
            services.AddScoped<IAchievementUserRepository, AchievementUserRepository>();
            services.AddScoped<IDeveloperRepository, DeveloperRepository>();
            services.AddScoped<IGameTimeRepository, GameTimeRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            

        }
    }
}
