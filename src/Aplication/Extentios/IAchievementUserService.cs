using Application.Abstractions;
using Application.Commons.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extentios
{
    public interface IAchievementUserService : IService<AchievementUserModel, AchievementUserCreateModel, AchievementUserEditModel>
    {
        Task<IEnumerable<AchievementUserModel>> GetByUserAndGame(Guid gameId, string email);
    }
}
