using Application.Commons.Models;
using Application.Extentios;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class AchievementUserRepository : Repository<AchievementUser, Guid>, IAchievementUserRepository
    {
        public AchievementUserRepository(AppDbContext ctx) : base(ctx) { }
        public async Task<bool> AnyAsync(Expression<Func<AchievementUser, bool>> predicate)
        {
            return await _ctx.AchievementUsers.AnyAsync(predicate);
        }

        public Task<List<AchievementUser>> GetAchievementsUserByGameId(Guid gameId)
        {
            return _ctx.AchievementUsers.Where(x => x.Achievement.GameId == gameId).ToListAsync();
        }
        public async Task<List<AchievementUser>> GetByUserAndGame(Guid gameId, Guid userId)
        {
            return await _ctx.AchievementUsers
                .Where(x => x.Achievement.GameId == gameId && x.UserId == userId)
                .ToListAsync();
        }
    }


}
