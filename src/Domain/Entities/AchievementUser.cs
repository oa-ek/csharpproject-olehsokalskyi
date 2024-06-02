using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("AchievementUsers")]
    public class AchievementUser : BaseEntity
    {
        [ForeignKey("Achievement")]
        public Guid AchievementId { get; set; }
        public virtual Achievement Achievement { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public virtual UserEntity User { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}
