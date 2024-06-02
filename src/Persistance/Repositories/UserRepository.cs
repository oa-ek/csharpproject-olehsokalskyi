using Application.Commons.Models;
using Application.Extentios;
using Application.Untils;
using AutoMapper;
using Domain.Entities;
using Domain.Primitives;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class UserRepository : Repository<UserEntity, Guid>, IUserRepository
    {
        private readonly IMapper _mapper;
        public UserRepository(AppDbContext ctx,IMapper mapper) : base(ctx) { _mapper = mapper; }


        public async Task BuyGame(UserEntity model, Guid gameId)
        {
            var userEntity = await _ctx.Users.FirstOrDefaultAsync(x => x.Id == model.Id);

            userEntity.Games.Add(await _ctx.Games.FirstAsync(x => x.Id == gameId));

            _ctx.Users.Update(userEntity);
            await _ctx.SaveChangesAsync();
        }

        public async Task<bool> CheckUser(Guid id)
        {
            return await _ctx.Users.AnyAsync(p => p.Id == id);
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public async Task<UserEntity> CreateUser(UserCreateDto model)
        {
            if (!IsValidEmail(model.Email))
            {
                throw new FormatException("Invalid email format. Please enter a valid email address.");
            }
            var user = _mapper.Map<UserEntity>(model);
            user.PasswordHash = PasswordHasher.Hash(model.Password);
            var role = _ctx.Roles.FirstOrDefault(r => r.Name == "User");
            user.RoleId = role.Id; 
            await _ctx.Users.AddAsync(user);
            await _ctx.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUser(UserEntity entity)
        {
            if (_ctx.Entry(entity).State == EntityState.Detached)
            {
                _ctx.Set<UserEntity>().Attach(entity);
            }
            _ctx.Set<UserEntity>().Remove(entity);
            await _ctx.SaveChangesAsync();

        }

        public async Task<IEnumerable<UserEntity>> GetAllWithRolesAsync()
        {
            return await _ctx.Users.ToListAsync();
        }
        public async Task<UserEntity> GetOneWithRolesAsync(Guid id)
        {
            return await _ctx.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateUserAsync(UserEntity model)
        {
            var user = _ctx.Users.Attach(model);
            user.Property(u => u.FirstName).IsModified = true;
            user.Property(u => u.LastName).IsModified = true;
            user.Property(u => u.UserName).IsModified = true;
            user.Property(u => u.Email).IsModified = true;
            await _ctx.SaveChangesAsync();
        }


        public async Task<UserEntity> GetByEmail(string Email)
        {
            return await _ctx.Users.FirstOrDefaultAsync(x => x.Email == Email);
        }

        public async Task ChangeRole(Guid userId, Guid rolesId)
        {
            var user = await _ctx.Users.FirstOrDefaultAsync(x => x.Id == userId);
            var role = await _ctx.Roles.FirstOrDefaultAsync(x => x.Id == rolesId);
            user.Role = role;
            _ctx.Users.Update(user);
            await _ctx.SaveChangesAsync();
        }
        public async Task BuyGame(UserModel model, Guid gameId)
        {
            var userEntity = await _ctx.Users.Include(u => u.Games).FirstOrDefaultAsync(x => x.Id == model.Id);
            var game = await _ctx.Games.FirstAsync(x => x.Id == gameId);
            userEntity.Games.Add(game);
            _ctx.Users.Update(userEntity);
            await _ctx.SaveChangesAsync();
        }
    }


}
