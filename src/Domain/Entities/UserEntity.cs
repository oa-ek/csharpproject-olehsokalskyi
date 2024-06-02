using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;   
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public virtual ICollection<Game> Games { get; set; } = new List<Game>();
        public virtual ICollection<GameTime> GameTimes { get; set; } = new List<GameTime>();
        public virtual ICollection<AchievementUser> Achievements { get; set; } = new List<AchievementUser>();
        [ForeignKey("Role")]
        public Guid RoleId { get; set; }
        public virtual RoleEntity Role { get; set; }
    }
}
