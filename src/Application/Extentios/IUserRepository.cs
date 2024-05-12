
using Application.Commons.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.IRepositories
{
    public interface IUserRepository : IRepository<UserEntity, Guid>
    {
        Task<IEnumerable<UserModel>> GetAllWithRolesAsync();
        Task<UserEntity> CreateWithPasswordAsync(UserCreateDto model);
        Task<IEnumerable<IdentityRole<Guid>>> GetRolesAsync();
        Task<UserModel> GetOneWithRolesAsync(Guid id);
        Task UpdateUserAsync(UserModel model, string[] roles);
        Task BuyGame(UserModel model, Guid gameId);

        Task<bool> CheckUser(Guid id);
        Task DeleteUser(Guid id);
    }
}
