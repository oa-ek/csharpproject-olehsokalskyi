using Application.Commons.Models;
using Application.Extentios;
using Application.Untils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController
        (IPublisherService publisherService): ControllerBase
    {
        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var result = await publisherService.GetListAsync();
            return Ok(result);
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add(PublisherCreateModel publisherCreateDto)
        {
            try
            {
                var result = await publisherService.AddAsync(publisherCreateDto);
                return Ok(result);
            }
            catch (ErrorMassage e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(PublisherEditModel publisherUpdateDto)
        {
            try
            {
                var result = await publisherService.UpdateAsync(publisherUpdateDto);
                return Ok(result);
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
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var result = await publisherService.DeleteAsync(id);
                return Ok(result);
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

    }
}
