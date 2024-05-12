
using Application.Abstractions.IRepositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class DeveloperRepository : Repository<Developer, Guid>, IDeveloperRepository
    {
        public DeveloperRepository(AppDbContext ctx) : base(ctx) { }
        public async Task<Developer> GetDeveloperByName(string name)
        {
            return await Task.Run(() => _ctx.Developers.FirstOrDefault(x => x.Title == name));
        }
    }

}
