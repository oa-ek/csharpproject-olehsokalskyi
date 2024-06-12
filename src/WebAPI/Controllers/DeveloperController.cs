using Application.Commons.Models;
using Application.Extentios;
using Application.Untils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly IDeveloperService _developerService;

        public DeveloperController(IDeveloperService developerService)
        {
            _developerService = developerService;
        }

        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var result = await _developerService.GetListAsync();
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Create(DeveloperCreateModel developerCreateDto)
        {
            try
            {
                var result = await _developerService.AddAsync(developerCreateDto);
                return Ok(result);
            }

            catch (ErrorMassage e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(Guid id, DeveloperEditModel developerUpdateDto)
        {
            try
            {
                var result = await _developerService.UpdateAsync(developerUpdateDto);
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
                var result = await _developerService.DeleteAsync(id);
                return Ok(result);
            }
            catch (ErrorMassage e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
