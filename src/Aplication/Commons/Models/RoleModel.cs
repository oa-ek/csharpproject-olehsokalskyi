using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commons.Models
{
    public class RoleModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public class RoleCreateDto
    {
        public string Name { get; set; }
    }
}
