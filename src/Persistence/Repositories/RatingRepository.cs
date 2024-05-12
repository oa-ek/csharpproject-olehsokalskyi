
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
    public class RatingRepository : Repository<Rating, Guid>, IRatingRepository
    {
        public RatingRepository(AppDbContext ctx) : base(ctx) { }
        public async Task<Rating> GetRatingByUserAndGame(Guid userId, Guid gameId)
        {
            return await _ctx.Ratings
                .FirstOrDefaultAsync(r => r.User.Id == userId && r.Game.Id == gameId);
        }
    }

}
