using Application.Commons.Models;
using Application.Extentios;
using Application.Untils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageService _languageService;

        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var result = await _languageService.GetListAsync();
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(LanguageCreateModel languageCreateDto)
        {
            
                var result = await _languageService.AddAsync(languageCreateDto);
                return Ok(result);
         
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(LanguageEditModel languageUpdateDto)
        {
            try
            {
                var result = await _languageService.UpdateAsync(languageUpdateDto);
                return Ok(result);
            }
            catch (ObjectNotFound e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var result = await _languageService.DeleteAsync(id);
                return Ok(result);
            }
            catch (ErrorMassage e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
