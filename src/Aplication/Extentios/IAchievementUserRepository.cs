using Application.Abstractions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extentios
{
    public interface IAchievementUserRepository : IRepository<AchievementUser, Guid>
    {
        Task<bool> AnyAsync(Expression<Func<AchievementUser, bool>> predicate);
        Task<List<AchievementUser>> GetAchievementsUserByGameId(Guid gameId);
    }
}
