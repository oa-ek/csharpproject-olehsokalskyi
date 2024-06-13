using Application.Abstractions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extentios
{
    public interface IAchievementRepository : IRepository<Achievement, Guid>
    {
        public Task<Achievement> GetAchievementByName(string name);
    }
}
