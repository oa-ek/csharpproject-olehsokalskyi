using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Core.Entities
{
    public class AchievementUser : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid AchievementId { get; set; }
        public virtual Achievement Achievement { get; set; }
        public virtual User User { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}
