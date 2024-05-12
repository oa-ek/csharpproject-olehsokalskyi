
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Commons.Models
{
    public class GameModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public double Price { get; set; } = 0;
        public string Trailer { get; set; } = string.Empty;
        public List<GenreModel> Genres { get; set; } = new List<GenreModel>();
        public List<PlatformModel> Platforms { get; set; } = new List<PlatformModel>();

        public PublisherModel? Publisher { get; set; } = new PublisherModel();
       // public IFormFile? ImagePath { get; set; } = null;

        public List<DeveloperViewModel> Developers { get; set; } = new List<DeveloperViewModel>();
        public List<AchievementViewModel> Achievements { get; set; } = new List<AchievementViewModel>();
        public List<LanguageModel> Languages { get; set; } = new List<LanguageModel>();
        public List<RatingModel> Ratings { get; set; } = new List<RatingModel>();
        public List<UserModel> Players { get; set; } = new List<UserModel>();
        public DateTime ReleaseDate { get; set; } = DateTime.UtcNow;

    }
    public class GameEditModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
       // public IFormFile? ImagePath { get; set; }
        public double Price { get; set; }
        public string Trailer { get; set; }
        public List<GenreModel> Genres { get; set; } = new List<GenreModel>();
        public List<PlatformModel> Platforms { get; set; } = new List<PlatformModel>();

        public PublisherModel? Publisher { get; set; } = new PublisherModel();

        public List<DeveloperViewModel> Developers { get; set; } = new List<DeveloperViewModel>();
        public List<LanguageModel> Languages { get; set; } = new List<LanguageModel>();
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
       // public IFormFile? Image { get; set; }
        public double Price { get; set; }
        public string Trailer { get; set; }
        public List<GenreModel> Genres { get; set; } = new List<GenreModel>();
        public List<PlatformModel> Platforms { get; set; } = new List<PlatformModel>();

        public PublisherModel? Publisher { get; set; } = new PublisherModel();

        public List<DeveloperViewModel> Developers { get; set; } = new List<DeveloperViewModel>();
        public List<LanguageModel> Languages { get; set; } = new List<LanguageModel>();
        public DateTime ReleaseDate { get; set; }

    }

}
