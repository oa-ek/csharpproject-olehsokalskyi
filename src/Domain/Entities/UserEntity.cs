using Domain.Primitives;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserEntity : IdentityUser<Guid>, IEntity<Guid>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public virtual ICollection<Game> Games { get; set; } = new List<Game>();
        public virtual ICollection<GameTime> GameTimes { get; set; } = new List<GameTime>();
        public virtual ICollection<AchievementUser> Achievements { get; set; } = new List<AchievementUser>();
    }
}
