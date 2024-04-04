using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Core.Entities
{
    public class Game
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Trailer { get; set; } = string.Empty;
        public double Price { get; set; } = 0;
        public virtual DateTime ReleaseDate { get; set; } = DateTime.UtcNow; 

        public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
        public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();
        public virtual ICollection<Developer> Developers { get; set; } = new List<Developer>(); 
        public virtual ICollection<Language> Languages { get; set; } = new List<Language>();
        public virtual ICollection<Platform> Platforms { get; set; } = new List<Platform>();
        public virtual ICollection<User> Players { get; set; } = new List<User>();

        public virtual Publisher Publisher { get; set; }
        public virtual Discount? Discount { get; set; }
    }
}
