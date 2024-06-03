using Application.Commons.Models;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commons
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Platform, PlatformViewModel>().ReverseMap();
            CreateMap<PlatformCreateModel, Platform>().ReverseMap();
            CreateMap<PlatformEditModel, Platform>().ReverseMap();


            CreateMap<Language, LanguageModel>().ReverseMap();
            CreateMap<LanguageCreateModel, Language>().ReverseMap();

            CreateMap<Genre, GenreModel>().ReverseMap();

            CreateMap<GenreCreateModel, Genre>().ReverseMap();


            CreateMap<Game, GameModel>().ReverseMap();
            CreateMap<GameLowViewModel, Game>().ReverseMap();
            CreateMap<GameCreateModel, Game>().ReverseMap();
            CreateMap<GameEditModel, Game>().ReverseMap();


            CreateMap<Developer, DeveloperViewModel>().ReverseMap();


            CreateMap<Developer, DeveloperCreateModel>().ReverseMap();

            CreateMap<AchievementUser, AchievementUserModel>().ReverseMap();
            CreateMap<AchievementUser, AchievementUserCreateModel>().ReverseMap();


            CreateMap<GameTime, GameTimeModel>().ReverseMap();
            CreateMap<GameTime, GameTimeCreateModel>().ReverseMap();
            CreateMap<GameTime, GameTimeEditModel>().ReverseMap();

            CreateMap<Rating, RatingModel>().ReverseMap();
            CreateMap<Rating, RatingCreateModel>().ReverseMap();
            CreateMap<Rating, RatingEditModel>().ReverseMap();
            CreateMap<Rating, RatingEditUserModel>().ReverseMap();


            CreateMap<Publisher, PublisherModel>().ReverseMap();
            CreateMap<Publisher, PublisherCreateModel>().ReverseMap();
            CreateMap<Publisher, PublisherEditModel>().ReverseMap();


            CreateMap<Achievement, AchievementViewModel>().ReverseMap();
            CreateMap<Achievement, AchievementCreateModel>().ReverseMap();
            CreateMap<Achievement, AchievementEditModel>().ReverseMap();



            CreateMap<UserCreateDto, UserEntity>().ReverseMap();
            CreateMap<UserEntity, UserModel>().ReverseMap();
            CreateMap<UserEntity, UserUpdateDto>().ReverseMap();
            CreateMap<UserModel,UserUpdateDto>().ReverseMap();
            CreateMap<UserModel, UserCreateDto>().ReverseMap();

            CreateMap<Genre, GenreEditModel>().ReverseMap();
            CreateMap<Language, LanguageEditModel>().ReverseMap();
            CreateMap<Platform, PlatformEditModel>().ReverseMap();
            CreateMap<Publisher, PublisherEditModel>().ReverseMap();
            CreateMap<Developer, DeveloperEditModel>().ReverseMap();

            CreateMap<RoleEntity, RoleModel>();


        }

    }
}
