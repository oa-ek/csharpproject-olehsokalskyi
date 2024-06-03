using Application.Commons.Models;
using Application.Extentios;
using Application.Untils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AchievementUserController : ControllerBase
    {
        private readonly IAchievementUserService _achievementUserService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AchievementUserController(IAchievementUserService achievementUserService,
            IHttpContextAccessor httpContextAccessor)
        {
            _achievementUserService = achievementUserService;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var result = await _achievementUserService.GetListAsync();
            return Ok(result);
        }
        [HttpPost("add")]
        [Authorize]
        public async Task<IActionResult> Add(AchievementUserCreateModel achievementUserCreateModel)
        {
            try
            {
                var email = _httpContextAccessor.HttpContext.Items["email"].ToString();
                achievementUserCreateModel.UserEmail = email;
                var result = await _achievementUserService.AddAsync(achievementUserCreateModel);
                return Ok(result);
            }
            catch (ErrorMassage e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var result = await _achievementUserService.DeleteAsync(id);
                return Ok(result);
            }
            catch (ErrorMassage e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _achievementUserService.GetByIdAsync(id);
            return Ok(result);
        } 
    }
}
