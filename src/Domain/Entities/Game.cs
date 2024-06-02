using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Games")]
    public class Game : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Trailer { get; set; } = string.Empty;
        public double Price { get; set; } = 0;
        public virtual DateTime ReleaseDate { get; set; } = DateTime.UtcNow;
        public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
        public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();
        public virtual ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();
        public virtual ICollection<Developer> Developers { get; set; } = new List<Developer>();
        public virtual ICollection<Language> Languages { get; set; } = new List<Language>();
        public virtual ICollection<Platform> Platforms { get; set; } = new List<Platform>();
        public virtual ICollection<UserEntity> Players { get; set; } = new List<UserEntity>();

        [ForeignKey("Publisher")]
        public Guid PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
