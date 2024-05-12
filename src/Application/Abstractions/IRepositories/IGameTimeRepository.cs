
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.IRepositories
{
    public interface IGameTimeRepository : IRepository<GameTime, Guid>
    {
        Task<GameTime> GetGameTimeByUserAndGame(Guid userId, Guid gameId);
    }
}
