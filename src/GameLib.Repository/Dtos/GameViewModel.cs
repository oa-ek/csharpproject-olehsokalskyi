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
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }   
        public string Trailer { get; set; }
        public List<GenreViewModel> Genres { get; set; }
        public List<PlatformViewModel> Platforms { get; set; }
        public PublisherViewModel Publisher { get; set; }
        public List<DeveloperViewModel> Developers { get; set; }
        public List<AchievementViewModel> Achievements { get; set; }
        public List<LanguageViewModel> Languages { get; set; }
        public List<RatingViewModel> Ratings { get; set; }
        public DateTime ReleaseDate { get; set; }
        
    }
    public class GameCreateModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public string Trailer { get; set; }
        public List<GenreViewModel> Genres { get; set; }
        public List<PlatformViewModel> Platforms { get; set; }
        public PublisherViewModel Publisher { get; set; }
        public List<DeveloperViewModel> Developers { get; set; }
        public List<AchievementViewModel> Achievements { get; set; }
        public List<LanguageViewModel> Languages { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
   
}
