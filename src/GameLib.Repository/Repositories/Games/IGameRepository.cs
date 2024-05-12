using GameLib.Core.Entities;
using GameLib.Repository.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Repository.Repositories.Games
{
    public interface IGameRepository : IRepository<Game, Guid>
    {
        public Task<Game> ExitGameByName (string name);

        public Task<List<Game>> GetGamesByUserIdAsync(Guid userId);
    }
}
