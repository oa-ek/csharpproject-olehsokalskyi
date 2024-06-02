using Application.Extentios;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class RoleRepository : Repository<RoleEntity, Guid>, IRoleRepository
    {
        public RoleRepository(AppDbContext ctx) : base(ctx) { }

        //public async Task<IEnumerable<RoleEntity>> GetByUser(Guid id)
        //{
        //    //var user = await _ctx.Users
        //    //    .FirstOrDefaultAsync(u => u.Id == id);

        //    //if (user == null)
        //    //{
        //    //    throw new Exception("User not found");
        //    //}

        //    //return user.UserRoles.Select(ur => ur.Role);
        //    //var user = await _ctx.Users.FirstOrDefaultAsync(u => u.Id == id);
        //    //return user.Roles;
        //}
    }
}
