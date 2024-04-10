using GameLib.Core.Entities;
using GameLib.Repository.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Repository.Repositories.AchievementUsers
{
    public interface IAchievementUserRepository : IRepository<AchievementUser, Guid>
    {
        Task<bool> AnyAsync(Expression<Func<AchievementUser, bool>> predicate);
    }
}
