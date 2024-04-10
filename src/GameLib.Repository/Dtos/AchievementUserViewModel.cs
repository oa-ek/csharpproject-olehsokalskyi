using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Repository.Dtos
{
    public class AchievementUserViewModel
    {
        public Guid Id { get; set; }
        public AchievementViewModel Achievement { get; set; }
        public UserDto User { get; set; }
        public DateTime Date { get; set; } 

    }
    public class AchievementUserCreateModel
    {
        public Guid AchievementId { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }


}
