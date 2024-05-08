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
        public double RatingValue { get; set; }
        public string Comment { get; set; } 
        public DateTime Date { get; set; } 
        public GameLowViewModel Game { get; set; }
        public UserDto User { get; set; }
    }
    public class RatingCreateModel
    {
        [Required]
        public double RatingValue { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required]
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public Guid GameId { get; set; }
        [Required]
        public Guid UserId { get; set; }
    }
    public class RatingEditModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public double RatingValue { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required]
        public DateTime Date { get; set; } = DateTime.UtcNow;
        [Required]
        public Guid GameId { get; set; }

        //[Required]
        //public Guid UserId { get; set; }
    }
    public class RatingEditUserModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public double RatingValue { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required]
        public DateTime Date { get; set; } = DateTime.UtcNow;
        [Required]
        public Guid GameId { get; set; }


    }
}
