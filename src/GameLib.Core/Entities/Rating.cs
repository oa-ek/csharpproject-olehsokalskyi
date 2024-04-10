using ProjectInit.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Core.Entities
{
    public class Rating : IEntity<Guid>
    {

        public Guid Id { get; set; } = Guid.NewGuid();
        public int RatingValue { get; set; } = 0;   
        public string Comment { get; set; } = string.Empty; 
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public virtual Game Game { get; set; }
        public virtual User User { get; set; }
    }
}
