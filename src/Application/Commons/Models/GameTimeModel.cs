using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commons.Models
{
    public class GameTimeModel
    {
        public Guid Id { get; set; }
        public DateTime LastPlayed { get; set; }
        public TimeSpan TotalTime { get; set; }
        public GameLowViewModel Game { get; set; }

        public UserModel User { get; set; }

    }
    public class GameTimeCreateModel
    {
        public Guid GameId { get; set; }

        public Guid UserId { get; set; }
    }
    public class GameTimeEditModel
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }

        public DateTime LastPlayed { get; set; } = DateTime.UtcNow;

        [DisplayFormat(DataFormatString = @"{0:hh\:mm}")]
        public TimeSpan TotalTime { get; set; }

    }
}
