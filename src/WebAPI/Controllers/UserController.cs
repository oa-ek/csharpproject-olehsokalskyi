using Application.Commons.Models;
using Application.Extentios;
using Application.Untils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoolMS.API.Auth;
using System.Data;
using System.Linq.Expressions;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(IUserService userService, IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _env = env;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("list")]
        [RoleAuth(Role = "Admin")]
        public async Task<IActionResult> List()
        {
            var result = await _userService.GetListAsync();
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            try
            {
                var result = await _userService.Login(userLoginDto);
                return Ok(new TokenModel {Token = result });
            }
            catch (ObjectNotFound e)
            {
                return NotFound(e.Message);
            }
            catch (InvalidPasswordException e)
            {
                return Unauthorized(e.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserCreateDto userCreateDto)
        {
            try
            {
                var result = await _userService.AddAsync(userCreateDto);
                return Ok(result);
            }
            catch(ErrorMassage e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
            
           
        }

        [HttpGet("getByEmail")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            try
            {
                var result = await _userService.GetByEmail(email);
                return Ok(result);
            }
            catch (ObjectNotFound e)
            {
                return NotFound(e.Message);
            }


            
        }
        [HttpPost("changeRole")]
        [RoleAuth(Role = "Admin")]
        public async Task<IActionResult> ChangeRole(UserRoleChangeDto model )
        {
            
            await _userService.ChangeRole(model);
            return Ok("Role Changed");
        }

        [HttpPost("changePassword")]
        public async Task<IActionResult> ChangePassword(UserChangePasswordDto userChangePasswordDto)
        {
            try
            {
                var result = await _userService.ChangePassword(userChangePasswordDto);
                return Ok(result);
            }
            catch(InvalidPasswordException e)
            {
                return BadRequest(e.Message);
            }
            catch (ObjectNotFound e)
            {
                return NotFound(e.Message);
            }
            catch (ErrorMassage e)
            {
                return BadRequest(e.Message);
            }
           
        }
        
        [HttpDelete("delete/{id}")]
        [RoleAuth(Role = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _userService.DeleteAsync(id);
                return Ok("Deleted");
            }

             catch (ObjectNotFound e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPut("update")]
        [RoleAuth(Role = "Admin")]
        public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
        {
            try
            {
                var result = await _userService.UpdateAsync(userUpdateDto);
                if (result == null)
                {
                    return BadRequest("Invalid data");
                }
                return Ok(result);
            }
            catch (ObjectNotFound e)
            {
                return NotFound(e.Message);
            }
        }
        //TODO: Отримання користувача по id
        [HttpGet("getCurrent")]
        public async Task<IActionResult> GetCurrent()
        {
            var email = _httpContextAccessor.HttpContext.Items["email"].ToString();
            var result = await _userService.GetCurrent(email);
            return Ok(result);
        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCurent(Guid id,UserUpdateDto userUpdateDto)
        {
            //var email = _httpContextAccessor.HttpContext.Items["email"].ToString();
            //userUpdateDto.Email = email;
            //if(userUpdateDto.Email != email)
            //{
            //    return BadRequest("Something went wrong");
            //}
            var result = await _userService.UpdateAsync(userUpdateDto);
            return Ok(result);
        }


       

    }
}
