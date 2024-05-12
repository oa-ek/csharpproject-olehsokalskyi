using GameLib.Core.Entities;
using GameLib.Repository.Dtos;
using GameLib.Repository.Repositories.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Repository.Repositories.UserRole
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        Task<IEnumerable<UserDto>> GetAllWithRolesAsync();
        Task<User> CreateWithPasswordAsync(UserCreateDto model);
        Task<IEnumerable<IdentityRole<Guid>>> GetRolesAsync();
        Task<UserDto> GetOneWithRolesAsync(Guid id);
        Task UpdateUserAsync(UserDto model, string[] roles);
        Task BuyGame(UserDto model, Guid gameId);

        Task<bool> CheckUser(Guid id);
        Task DeleteUser(Guid id);
    }
}
