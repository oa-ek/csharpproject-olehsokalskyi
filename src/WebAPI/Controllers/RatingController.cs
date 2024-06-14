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
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public RatingController(IRatingService ratingService, IHttpContextAccessor httpContextAccessor)
        {
            _ratingService = ratingService;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var result = await _ratingService.GetListAsync();
            return Ok(result);
        }
        [HttpPost("add")]
        [Authorize]
        public async Task<IActionResult> Add(RatingCreateModel ratingCreateModel)
        {
            try
            {
                var email = _httpContextAccessor.HttpContext.Items["email"].ToString();
                ratingCreateModel.UserEmail = email;
                var result = await _ratingService.AddAsync(ratingCreateModel);
                return Ok(result);
            }
            catch(ObjectAlreadyExistException e)
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
                var result = await _ratingService.DeleteAsync(id);
                return Ok(result);
            }
            catch (ErrorMassage e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("update/{id}")]
        [Authorize]
        public async Task<IActionResult> Update(Guid id, RatingEditModel ratingEditModel)
        {
            try
            {
                var email = _httpContextAccessor.HttpContext.Items["email"].ToString();
                ratingEditModel.UserEmail = email;
                var result = await _ratingService.UpdateAsync(ratingEditModel);
                return Ok(result);
            }
            catch (ErrorMassage e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
