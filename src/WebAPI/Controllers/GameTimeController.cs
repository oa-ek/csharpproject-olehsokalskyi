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
    public class GameTimeController : ControllerBase
    {
        private readonly IGameTimeService _gameTimeService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public GameTimeController(IGameTimeService gameTimeService, IHttpContextAccessor httpContextAccessor)
        {
            _gameTimeService = gameTimeService;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var result = await _gameTimeService.GetListAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _gameTimeService.GetByIdAsync(id);
            return Ok(result);
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add(GameTimeCreateModel gameTimeCreateModel)
        {
            try
            {
                var email = _httpContextAccessor.HttpContext.Items["email"].ToString();
                gameTimeCreateModel.UserEmail = email;
                var result = await _gameTimeService.AddAsync(gameTimeCreateModel);
                return Ok(result);
            }
            catch (ErrorMassage e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("update/{id}")]
        [Authorize]
        public async Task<IActionResult> Update(Guid id, GameTimeEditModel gameTimeUpdateModel)
        {
            try
            {
                var email = _httpContextAccessor.HttpContext.Items["email"].ToString();
                gameTimeUpdateModel.UserEmail = email;
                var result = await _gameTimeService.UpdateAsync(gameTimeUpdateModel);

                return Ok(result);
            }
            catch (ObjectNotFound e)
            {
                return BadRequest(e.Message);
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
                var result = await _gameTimeService.DeleteAsync(id);
                return Ok(result);
            }
            catch (ErrorMassage e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
