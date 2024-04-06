using GameLib.Core.Context;
using GameLib.Core.Entities;
using GameLib.Repository.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Repository.Repositories.UserRole
{
    public class UserRepository
    {
        private readonly AppDbContext _ctx;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        public UserRepository(AppDbContext ctx,
           UserManager<User> userManager,
           RoleManager<IdentityRole<Guid>> roleManager)
        {
            _ctx = ctx;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<User> CreateAsync(UserCreateDto userCreateDto)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = userCreateDto.FirstName,
                LastName = userCreateDto.LastName,
                Email = userCreateDto.Email,
                UserName = userCreateDto.UserName

            };
            var result = await _userManager.CreateAsync(user, userCreateDto.Password);
            return await _ctx.Users.FirstAsync(x => x.Email == userCreateDto.Email);
        }
        public async Task<IEnumerable<IdentityRole>> GetRolesAsync()
        {
            return (IEnumerable<IdentityRole>)await _ctx.Roles.ToListAsync();
            
        }
        public async Task UpdateAsync(UserDto model, string[] roles)
        {
            var user = _ctx.Users.Find(model.Id);

            if (user.Email != model.Email)
            {
                user.Email = model.Email;
                user.UserName = model.Email;
                user.NormalizedEmail = model.Email.ToUpper();
            }

            if (user.FirstName != model.FirstName)
                user.FirstName = model.FirstName;

            if (user.LastName != model.LastName)
                user.LastName = model.LastName;

          
            var admRole = await _roleManager.FindByNameAsync("Admin");

            if ((await _userManager.GetRolesAsync(user)).Any())
            {
                await _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user));
            }

            if (roles.Any())
            {
                await _userManager.AddToRolesAsync(user, roles.ToList());
            }
        }
        public async Task DeleteAsync(Guid id)
        {
            var user = _ctx.Users.Find(id);

            if ((await _userManager.GetRolesAsync(user)).Any())
            {
                await _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user));
            }
            await _userManager.DeleteAsync(user);
        }
        public async Task<IEnumerable<UserDto>> GetAllWithRolesAsync()
        {
            var list = new List<UserDto>();

            foreach (var user in await _ctx.Users.ToListAsync())
                list.Add(await GetOneWithRolesAsync(user.Id));

            return list;
        }

        public async Task<UserDto> GetOneWithRolesAsync(Guid id)
        {
            var user = await _ctx.Users.FirstAsync(x => x.Id == id);
            var userModel = new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,    
                Roles = new List<IdentityRole<Guid>>()
            };

            foreach (var role in await _userManager.GetRolesAsync(user))
            {
                userModel.Roles.Add(await _ctx.Roles.FirstAsync(x => x.Name.ToLower() == role.ToLower()));
            }

            return userModel;
        }

    }

}
