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
    public class PlatformRepository : Repository<Platform, Guid>, IPlatformRepository
    {
        public PlatformRepository(AppDbContext ctx) : base(ctx) { }
        public async Task<Platform> GetPlatformByName(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            return await _ctx.Platforms.FirstOrDefaultAsync(p => p.Title == name);
        }
    }

}
