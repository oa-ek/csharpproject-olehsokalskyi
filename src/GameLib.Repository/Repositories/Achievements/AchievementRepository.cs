using GameLib.Core.Context;
using GameLib.Core.Entities;
using GameLib.Repository.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Repository.Repositories.Achievements
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
