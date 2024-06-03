using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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

        [JsonIgnore]
        public string? UserEmail { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
    public class AchievementUserEditModel
    {
        public Guid Id { get; set; }
        public Guid AchievementId { get; set; }
        public string? UserEmail { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }



}
