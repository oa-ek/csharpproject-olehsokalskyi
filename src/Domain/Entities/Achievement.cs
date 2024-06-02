using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Achievements")]
    public class Achievement : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int PlayersGet { get; set; } = 0;
        [ForeignKey("Game")]
        public Guid GameId { get; set; }
        public virtual Game? Game { get; set; }
    }
}
