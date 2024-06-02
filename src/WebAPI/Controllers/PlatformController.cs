using Application.Commons.Models;
using Application.Extentios;
using Application.Untils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformService _platformService;
        public PlatformController(IPlatformService platformService)
        {
            _platformService = platformService;
        }
        [HttpGet("list")]   
        public async Task<IActionResult> List()
        {
            var result = await _platformService.GetListAsync();
            return Ok(result);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(PlatformCreateModel platformCreateDto)
        {
            try
            {
                var result = await _platformService.AddAsync(platformCreateDto);
                return Ok(result);
            }
            catch (ErrorMassage e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(PlatformEditModel platformUpdateDto)
        {
            try
            {
                var result = await _platformService.UpdateAsync(platformUpdateDto);
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
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var result = await _platformService.DeleteAsync(id);
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
