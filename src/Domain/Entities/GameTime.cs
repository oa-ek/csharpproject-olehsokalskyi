using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GameTime : BaseEntity
    {
        public TimeSpan TotalTime { get; set; } = TimeSpan.Zero;
        public DateTime LastPlayed { get; set; } = DateTime.Now;

        [ForeignKey("Game")]
        public Guid GameId { get; set; }
        public virtual Game Game { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public virtual UserEntity User { get; set; }

    }
}
