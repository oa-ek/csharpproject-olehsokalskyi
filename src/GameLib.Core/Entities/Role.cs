using ProjectInit.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Core.Entities
{
    public class Role : IEntity<Guid>
    {

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public virtual ICollection<User> Users { get; set; } = new List<User>();    
    }
}
