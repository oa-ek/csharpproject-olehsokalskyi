using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Primitives
{
    public abstract class BaseEntity: IEntity<Guid>
    {
        
        public Guid Id { get; set; } = new Guid();
    }
}
