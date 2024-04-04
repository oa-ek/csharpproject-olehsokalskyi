using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Core.Entities
{
    public class GameTime
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public TimeSpan TotalTime { get; set; } = TimeSpan.Zero;
        public DateTime LastPlayed { get; set; } = DateTime.Now;    
        public virtual Game Game { get; set; }
        public virtual User User { get; set; }
    }
}
