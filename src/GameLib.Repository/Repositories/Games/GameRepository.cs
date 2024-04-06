using GameLib.Core.Context;
using GameLib.Core.Entities;
using GameLib.Repository.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Repository.Repositories.Games
{
    public class GameRepository : Repository<Game, Guid>, IGameRepository
    {
        public GameRepository(AppDbContext ctx) : base(ctx) { }
    }

}
