using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Languages")]
    public class Language : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public virtual ICollection<Game> Games { get; set; } = new List<Game>();
    }
}
