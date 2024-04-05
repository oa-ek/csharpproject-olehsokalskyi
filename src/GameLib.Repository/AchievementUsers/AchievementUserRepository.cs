using GameLib.Core.Context;
using GameLib.Core.Entities;
using GameLib.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Repository.AchievementUsers
{
    public class AchievementUserRepository : Repository<AchievementUser, Guid>, IAchievementUserRepository
    {
        public AchievementUserRepository(AppDbContext ctx) : base(ctx) { }
    }
    
   
}
