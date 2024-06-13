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
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GameController(IGameService gameService, IHttpContextAccessor httpContextAccessor)
        {
            _gameService = gameService;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var result = await _gameService.GetListAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _gameService.GetByIdAsync(id);
            return Ok(result);
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add(GameCreateModel gameCreateDto)
        {
            try
            {
                var result = await _gameService.AddAsync(gameCreateDto);
                return Ok(result);
            }

            catch (ErrorMassage e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(Guid id, GameEditModel gameUpdateDto)

        {
            try
            {
                var result = await _gameService.UpdateAsync(gameUpdateDto);
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
                var result = await _gameService.DeleteAsync(id);
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
        [HttpPost("buygame/{gameId}")]
        [Authorize]
        public async Task<IActionResult> BuyGame(Guid gameId)
        {
            try
            {
                var email = _httpContextAccessor.HttpContext.Items["email"].ToString();
                var result = await _gameService.BuyGame(new GameBuyModel { EmailUser = email, GameId = gameId });
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
        [HttpGet("getgamefromapi")]
        public async Task<IActionResult> GetGameFromAPI()
        {
            try
            {
                var result = await _gameService.GetGameFromAPI();
                return Ok(result);
            }
            catch (ErrorMassage e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("get/{id}")]
        public async Task<IActionResult> Detail(Guid id)
        {
            try
            {
                var result = await _gameService.GetByIdAsync(id);
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



    }
}
