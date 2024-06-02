using Application.Abstractions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extentios
{
    public interface IRatingRepository : IRepository<Rating, Guid>
    {
        Task<Rating> GetRatingByUserAndGame(Guid userId, Guid gameId);

    }
}
