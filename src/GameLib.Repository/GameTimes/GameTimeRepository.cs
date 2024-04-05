using GameLib.Core.Context;
using GameLib.Core.Entities;
using GameLib.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Repository.GameTimes
{
    public class GameTimeRepository : Repository<GameTime, Guid>, IGameTimeRepository
    {
        public GameTimeRepository(AppDbContext ctx) : base(ctx) { }
    }
  
}
