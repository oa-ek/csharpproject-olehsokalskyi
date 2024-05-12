using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Core.Entities
{
    public class User: IdentityUser<Guid>, IEntity<Guid>
    {
    
        //public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        //public string UserDisplayName { get; set; } = string.Empty;

        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public virtual ICollection<Game> Games { get; set; } = new List<Game>();
        public virtual ICollection<GameTime> GameTimes { get; set; } = new List<GameTime>();
        public virtual ICollection<AchievementUser> Achievements { get; set; } = new List<AchievementUser>();
        //public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
    }
}
