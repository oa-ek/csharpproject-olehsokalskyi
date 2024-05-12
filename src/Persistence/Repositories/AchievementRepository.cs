
using Application.Abstractions.IRepositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class AchievementRepository : Repository<Achievement, Guid>, IAchievementRepository
    {
        public AchievementRepository(AppDbContext ctx) : base(ctx) { }
        public async Task<Achievement> GetAchievementByName(string name)
        {
            return await _ctx.Achievements.FirstOrDefaultAsync(a => a.Title == name);
        }

    }
}
