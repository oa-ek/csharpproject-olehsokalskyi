using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Core.Entities
{
    public class Achievement : IEntity<Guid>
    {

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid GameId { get; set; } 
        public virtual Game Game { get; set; }
        public int PlayersGet { get; set; } = 0;


    }
}
