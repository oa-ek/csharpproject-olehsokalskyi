using GameLib.Core.Context;
using GameLib.Core.Entities;
using GameLib.Repository.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Repository.Repositories.GameTimes
{
    public class GameTimeRepository : Repository<GameTime, Guid>, IGameTimeRepository
    {
        public GameTimeRepository(AppDbContext ctx) : base(ctx) { }
    }

}
