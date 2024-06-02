using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Rating : BaseEntity
    {
        public double RatingValue { get; set; } = 0;
        public string Comment { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.UtcNow;

        [ForeignKey("Game")]
        public Guid GameId { get; set; }
        public virtual Game Game { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public virtual UserEntity User { get; set; }
    }
}
