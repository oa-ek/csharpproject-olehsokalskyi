using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GameLib.Repository.Dtos
{
    public class GameViewModel
    {
        public Guid Id { get; set; } 
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public double Price { get; set; } = 0;
        public string Trailer { get; set; } = string.Empty;
        public List<GenreViewModel> Genres { get; set; } = new List<GenreViewModel>();
        public List<PlatformViewModel> Platforms { get; set; } = new List<PlatformViewModel>();

        public PublisherViewModel? Publisher { get; set; } = new PublisherViewModel();
        public IFormFile? ImagePath { get; set; } = null;

        public List<DeveloperViewModel> Developers { get; set; } = new List<DeveloperViewModel>();
        public List<AchievementViewModel> Achievements { get; set; } = new List<AchievementViewModel>();
        public List<LanguageViewModel> Languages { get; set; } = new List<LanguageViewModel>();
        public List<RatingViewModel> Ratings { get; set; } = new List<RatingViewModel>();
        public List<UserDto> Players { get; set; } = new List<UserDto>();
        public DateTime ReleaseDate { get; set; } = DateTime.UtcNow;
        
    }
    public class GameEditModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile? ImagePath { get; set; }
        public double Price { get; set; }
        public string Trailer { get; set; }
        public List<GenreViewModel> Genres { get; set; } = new List<GenreViewModel>();
        public List<PlatformViewModel> Platforms { get; set; } = new List<PlatformViewModel>();

        public PublisherViewModel? Publisher { get; set; } = new PublisherViewModel();

        public List<DeveloperViewModel> Developers { get; set; } = new List<DeveloperViewModel>();
        public List<LanguageViewModel> Languages { get; set; } = new List<LanguageViewModel>();
        public DateTime ReleaseDate { get; set; }
    }
    public class GameLowViewModel()
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public string Trailer { get; set; }

    }
    public class GameCreateModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile? Image { get; set; }
        public double Price { get; set; }
        public string Trailer { get; set; }
        public List<GenreViewModel> Genres { get; set; } = new List<GenreViewModel>();
        public List<PlatformViewModel> Platforms { get; set; } = new List<PlatformViewModel>();

        public PublisherViewModel? Publisher { get; set; } = new PublisherViewModel();

        public List<DeveloperViewModel> Developers { get; set; }= new List<DeveloperViewModel>();
        public List<LanguageViewModel> Languages { get; set; } = new List<LanguageViewModel>();
        public DateTime ReleaseDate { get; set; }

    }
   
}
