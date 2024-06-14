using Application.Commons.Models;
using Application.Extentios;
using Application.Untils;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class UserService : IUserService
    {
        private readonly UserManagerService _userManagerService;
        private readonly IMapper _mapper;

        public UserService(UserManagerService userManagerService,
            IMapper mapper)
        {
            _userManagerService = userManagerService;
            _mapper = mapper;
        }

        public async Task<DefaultMessageResponse> AddAsync(UserCreateDto model)
        {
            try
            {
                var user = await _userManagerService.CreateUser(model);
                return new DefaultMessageResponse { Message = "Registration success" };
            }
            catch (Exception ex)
            {
                throw new ErrorMassage(ex.Message);
            }

        }


        public async Task<DefaultMessageResponse> ChangePassword(UserChangePasswordDto userChangePasswordDto)
        {
            try
            {
                await _userManagerService.ChangePassword(userChangePasswordDto);
                return new DefaultMessageResponse { Message = "Password changed successfully" };
            }
            catch(ObjectNotFound)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ErrorMassage(ex.Message);
            }
           
        }
        public async Task<IEnumerable<RoleModel>> GetAllRole()
        {
            return _mapper.Map<IEnumerable<RoleModel>>(await _userManagerService.GetAllRoles());
        }

        public async Task<DefaultMessageResponse> DeleteAsync(Guid id)
        {
            try
            {
                await _userManagerService.DeleteUser(id);
                return new DefaultMessageResponse { Message = "User deleted successfully" };
            }
            catch (ObjectNotFound)
            {
                throw;
            }
            catch (InvalidPasswordException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ErrorMassage(ex.Message);
            }
            
        }

        public async Task<UserModel> GetByEmail(string email)
        {
            try
            {
                return _mapper.Map<UserModel>(await _userManagerService.GetUserByEmail(email));
            }
            catch (ObjectNotFound)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ErrorMassage(ex.Message);
            }
         
        }

        public async Task<UserModel> GetByIdAsync(Guid id)
        {
            try
            {
                var user = await _userManagerService.GetUserById(id);
                return user;
            }
            catch (ObjectNotFound)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ErrorMassage(ex.Message);
            }
         
        }

        public async Task<IEnumerable<UserModel>> GetListAsync()
        {
            try
            {
                var users = await _userManagerService.GetAllUsers();
                return users;
            }
            catch(Exception ex)
            {
                throw new ErrorMassage(ex.Message);
            }
           
        }

        public async Task<string> Login(UserLoginDto userLoginDto)
        {
            try
            {
                var token = await _userManagerService.Authorize(userLoginDto);
                return token;
            }
            catch (ObjectNotFound)
            {
                throw;
            }
            catch (InvalidPasswordException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ErrorMassage(ex.Message);
            }
        }


        public async Task<DefaultMessageResponse> UpdateAsync(UserUpdateDto model)
        {
            try
            {
                await _userManagerService.EditUser(model);
                return new DefaultMessageResponse { Message = "User updated successfully" };
            }
            catch (ObjectNotFound)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ErrorMassage(ex.Message);
            }
        }
        public async Task<DefaultMessageResponse> ChangeRole(UserRoleChangeDto model)
        {
            try
            {
                var user =  await _userManagerService.ChangeRole(model);
                return new DefaultMessageResponse { Message = $"Role changed successfully to {user.Role.Name}" };
            }
            catch (ObjectNotFound)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ErrorMassage(ex.Message);
            }
        }
        public async Task<UserModel> GetCurrent(string email)
        {
            try
            {

                var user = await _userManagerService.GetUserByEmail(email);
                return _mapper.Map<UserModel>(user);
            }
            catch (ObjectNotFound)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ErrorMassage(ex.Message);
            }
        }
        public async Task<DefaultMessageResponse> UpdateCurrentcy(UserUpdateDto model)
        {
            try
            {
                await _userManagerService.EditUser(model);
                return new DefaultMessageResponse { Message = "Currency updated successfully" };
            }
            catch (ObjectNotFound)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ErrorMassage(ex.Message);
            }
        }
    }
}
