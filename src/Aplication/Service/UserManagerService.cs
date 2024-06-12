using Application.Abstractions;
using Application.Commons.Models;
using Application.Extentios;
using Application.Untils;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class UserManagerService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IJwtProvider _jwtProvider;
        private readonly IMapper _mapper;
        public UserManagerService(IUserRepository userRepository, IRoleRepository roleRepository, IMapper mapper, IJwtProvider jwtProvider)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _jwtProvider = jwtProvider;
            _mapper = mapper;
        }
        public async Task<IEnumerable<RoleEntity>> GetAllRoles()
        {
            return await _roleRepository.GetAllAsync();
        }

        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            
                var users = _mapper.Map<IEnumerable<UserModel>>(await _userRepository.GetAllWithRolesAsync());
                return users;
          
          
        }
        public async Task<UserModel> ChangeRole(UserRoleChangeDto model)
        {
                var user = _mapper.Map<UserEntity>(await _userRepository.GetAsync(model.UserId));
                if (user is null)
                    throw new ObjectNotFound("User not found");
                await _userRepository.ChangeRole(model.UserId, model.RoleId);
                return _mapper.Map<UserModel>(user);
          
        }
        public async Task<UserModel> GetUserById(Guid id)
        {
           
                var user = _mapper.Map<UserModel>(await _userRepository.GetOneWithRolesAsync(id));
                if (user is null)
                    throw new ObjectNotFound("User not found");
                return user;
           

        }
        public async Task<string> Authorize(UserLoginDto userLogin)
        {
            
                var user = await _userRepository.GetByEmail(userLogin.Email);
                if (user == null)
                    throw new ObjectNotFound("User not found");
                else if (!PasswordHasher.Verify(user.PasswordHash, userLogin.Password))
                    throw new InvalidPasswordException("Invalid password");

                return _jwtProvider.Generate(user);
        
          
        }

        public async Task<UserEntity> GetUserByEmail(string email)
        {
                var user = await _userRepository.GetByEmail(email);
                if (user == null)
                    throw new ObjectNotFound("User not found");
                return user;
            
        }
        public async Task ChangePassword(UserChangePasswordDto model)
        {
                var user = await _userRepository.GetAsync(model.Id);
                if (PasswordHasher.Verify(user.PasswordHash, model.OldPassword))
                    user.PasswordHash = PasswordHasher.Hash(model.NewPassword);
                await _userRepository.UpdateAsync(user);

                throw new InvalidPasswordException("Password is incorrect");
           

        }
        public async Task<UserModel> CreateUser(UserCreateDto model)
        {
            
                await _userRepository.CreateUser(model);
                return _mapper.Map<UserModel>(model);
           
          
        }
        public async Task<UserModel> EditUser(UserUpdateDto model)
        {
            var userEntity = await _userRepository.GetAsync(model.Id);
            if (userEntity == null)
            {
                throw new ObjectNotFound("User not found");
            }

            // Update the user properties
            userEntity.FirstName = model.FirstName;
            userEntity.LastName = model.LastName;
            userEntity.Email = model.Email;
            userEntity.UserName = model.UserName;

            await _userRepository.UpdateUserAsync(userEntity);
            return _mapper.Map<UserModel>(userEntity);


        }
        public async Task DeleteUser(Guid id)
        {
            
                var user = await _userRepository.GetAsync(id);
                if (user is null)
                    throw new ObjectNotFound("User not found");
                await _userRepository.DeleteAsync(id);

            
           
        }
       
    }
}
