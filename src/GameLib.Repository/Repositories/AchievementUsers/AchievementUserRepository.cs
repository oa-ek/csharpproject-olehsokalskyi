using GameLib.Core.Context;
using GameLib.Core.Entities;
using GameLib.Repository.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Repository.Repositories.AchievementUsers
{
    public class AchievementUserRepository : Repository<AchievementUser, Guid>, IAchievementUserRepository
    {
        public AchievementUserRepository(AppDbContext ctx) : base(ctx) { }
    }


}
