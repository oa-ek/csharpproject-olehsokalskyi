
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
    public class GameTimeRepository : Repository<GameTime, Guid>, IGameTimeRepository
    {
        public GameTimeRepository(AppDbContext ctx) : base(ctx) { }

        public async Task<GameTime> GetGameTimeByUserAndGame(Guid userId, Guid gameId)
        {
            return await _ctx.GameTimes
                .FirstOrDefaultAsync(r => r.User.Id == userId && r.Game.Id == gameId);
        }
    }
}
