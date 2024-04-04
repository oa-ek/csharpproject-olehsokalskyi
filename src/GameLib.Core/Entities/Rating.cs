using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Core.Entities
{
    public class Rating
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public int RatingValue { get; set; }    
        public string Comment { get; set; } = string.Empty; 
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public virtual Game Game { get; set; }
        public virtual User User { get; set; }
    }
}
