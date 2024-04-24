using AutoMapper;
using GameLib.Repository.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLib.Core.Entities;


namespace GameLib.Repository.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Platform, PlatformViewModel>().ReverseMap();
            CreateMap<PlatformCreateModel, Platform>().ReverseMap();
            CreateMap<PlatformEditModel, Platform>().ReverseMap();


            CreateMap<Language, LanguageViewModel>().ReverseMap();
            CreateMap<LanguageCreateModel, Language>().ReverseMap();

            CreateMap<Genre, GenreViewModel>().ReverseMap();
            CreateMap<GenreCreateModel, Genre>().ReverseMap();


            CreateMap<Game, GameViewModel>().ReverseMap();
            CreateMap<GameLowViewModel, Game>().ReverseMap();
            CreateMap<GameCreateModel, Game>().ReverseMap();
            CreateMap<GameEditModel, Game>().ReverseMap();


            CreateMap<Payment, PaymentViewModel>().ReverseMap();
            CreateMap<Payment, PaymentCreateModel>().ReverseMap();


            CreateMap<Developer, DeveloperViewModel>().ReverseMap();
        

            CreateMap<Developer, DeveloperCreateModel>().ReverseMap();

            CreateMap<AchievementUser, AchievementUserViewModel>().ReverseMap();
            CreateMap<AchievementUser, AchievementUserCreateModel>().ReverseMap();


            CreateMap<GameTime, GameTimeViewModel>().ReverseMap();
            CreateMap<GameTime, GameTimeCreateModel>().ReverseMap();

            CreateMap<Rating, RatingViewModel>().ReverseMap();
            CreateMap<Rating, RatingCreateModel>().ReverseMap();
            CreateMap<Rating, RatingEditModel>().ReverseMap();

            CreateMap<Publisher, PublisherViewModel>().ReverseMap();
            CreateMap<Publisher, PublisherCreateModel>().ReverseMap();
            CreateMap<Publisher, PublisherEditModel>().ReverseMap();


            CreateMap<Achievement, AchievementViewModel>().ReverseMap();
            CreateMap<Achievement, AchievementCreateModel>().ReverseMap();
            CreateMap<Achievement, AchievementEditModel>().ReverseMap();



            CreateMap<UserCreateDto, User>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();

            CreateMap<Genre, GenreEditModel>().ReverseMap();
            CreateMap<Language, LanguageEditModel>().ReverseMap();
            CreateMap<Platform, PlatformEditModel>().ReverseMap();
            CreateMap<Publisher, PublisherEditModel>().ReverseMap();
            CreateMap<Developer, DeveloperEditModel>().ReverseMap();
          






















        }

    }
}
