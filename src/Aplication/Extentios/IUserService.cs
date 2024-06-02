using Application.Abstractions;
using Application.Commons.Models;

//using Application.Commons;
using Domain.Entities;
using Microsoft.AspNetCore.Hosting.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extentios
{
    public interface IUserService : IService<UserModel,UserCreateDto, UserUpdateDto>
    {
        public Task<string> Login(UserLoginDto userLoginDto);
        public Task<UserModel> GetByEmail(string email);
        public Task<DefaultMessageResponse> ChangePassword(UserChangePasswordDto userChangePasswordDto);
        public Task<DefaultMessageResponse> ChangeRole(UserRoleChangeDto userRoleChangeDto);

        //public Task<DefaultMessageResponse> AddReles(Guid userId, List<Guid> rolesId);
        //public Task<DefaultMessageResponse> RemoveRoles(Guid userId, List<Guid> rolesId);

    }
    public class TokenModel
    {
        public string Token { get; set; }
    }
}
