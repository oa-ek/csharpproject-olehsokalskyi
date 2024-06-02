using Application.Abstractions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extentios
{
    public interface IRoleRepository : IRepository<RoleEntity, Guid>
    {
        //public Task<IEnumerable<RoleEntity>> GetByUser(Guid id);
    }
}
