using Application.Commons.Models;
using Application.Extentios;
using Application.Untils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoolMS.API.Auth;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var result = await _genreService.GetListAsync();
            return Ok(result);
        }

        [HttpPost("add")]
        [RoleAuth(Role = "Admin")]
        public async Task<IActionResult> Add(GenreCreateModel genreCreateDto)
        {
            try
            {
                var result = await _genreService.AddAsync(genreCreateDto);
                return Ok(result);
            }
            catch (ErrorMassage e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("update")]
        [RoleAuth(Role = "Admin")]
        public async Task<IActionResult> Update(GenreEditModel genreUpdateDto)
        {
            try
            {
                var result = await _genreService.UpdateAsync(genreUpdateDto);
                return Ok(result);
            }
            catch (ErrorMassage e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("delete")]
        [RoleAuth(Role = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var result = await _genreService.DeleteAsync(id);
                return Ok(result);
            }
            catch (ErrorMassage e)
            {
                return BadRequest(e.Message);
            }
        }   
    }
}
