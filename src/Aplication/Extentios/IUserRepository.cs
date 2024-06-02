using Application.Abstractions;
using Application.Commons.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extentios
{
    public interface IUserRepository : IRepository<UserEntity, Guid>
    {
        Task<IEnumerable<UserEntity>> GetAllWithRolesAsync();
        Task<UserEntity> CreateUser(UserCreateDto model);
        Task ChangeRole(Guid userId, Guid rolesId);
        Task<UserEntity> GetOneWithRolesAsync(Guid id);
        Task UpdateUserAsync(UserEntity model);
        Task BuyGame(UserEntity model, Guid gameId);
        Task<UserEntity> GetByEmail(string Email);
        Task<bool> CheckUser(Guid id);
        Task DeleteUser(UserEntity entity);
    }
}
