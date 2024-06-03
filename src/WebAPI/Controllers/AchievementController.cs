using Application.Commons.Models;
using Application.Extentios;
using Application.Untils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AchievementController : ControllerBase
    {
        private readonly IAchievementService _achirwmentService;
        public AchievementController(IAchievementService achirwmentService)
        {
            _achirwmentService = achirwmentService;
        }

        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var result = await _achirwmentService.GetListAsync();
            return Ok(result);
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add(AchievementCreateModel achievmentCreateDto)
        {
            try
            {
                var result = await _achirwmentService.AddAsync(achievmentCreateDto);
                return Ok(result);
            }
            catch (ErrorMassage e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("update/{id}")]    
        public async Task<IActionResult> Update(Guid id, AchievementEditModel achievementUpdateModel)
        {
            try
            {
                var result = await _achirwmentService.UpdateAsync(achievementUpdateModel);
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
                var result = await _achirwmentService.DeleteAsync(id);
                return Ok(result);
            }
            catch (ErrorMassage e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
