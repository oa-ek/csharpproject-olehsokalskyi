using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Repository.Dtos
{
    public class RatingViewModel
    {
        public Guid Id { get; set; }
        public int RatingValue { get; set; }
        public string Comment { get; set; } 
        public DateTime Date { get; set; } 
        public GameViewModel Game { get; set; }
        public UserDto User { get; set; }
    }
    public class RatingCreateModel
    {
        [Required]
        public int RatingValue { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required]
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public GameViewModel Game { get; set; }
        [Required]
        public UserDto User { get; set; }
    }
}
