using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commons.Models
{
    public class AchievementUserModel
    {
        public Guid Id { get; set; }
        public AchievementViewModel Achievement { get; set; }
        public UserModel User { get; set; }
        public DateTime Date { get; set; }

    }
    public class AchievementUserCreateModel
    {
        public Guid AchievementId { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }


}
