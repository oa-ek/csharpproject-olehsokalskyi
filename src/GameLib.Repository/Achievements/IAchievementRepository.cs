using GameLib.Core.Entities;
using GameLib.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Repository.Achievements
{
    public interface IAchievementRepository : IRepository<Achievement, Guid>
    {
    }
}
