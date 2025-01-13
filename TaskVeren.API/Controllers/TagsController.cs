using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskVeren.Business.DTOs.Tag;
using TaskVeren.Business.Services.Interfaces;

namespace TaskVeren.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        readonly ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _tagService.GetById(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
   
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] CreateTagDto dto)
        {
            try
            {
                return Ok(await _tagService.CreateAsync(dto));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, ex.Message);
            }
       
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateTagDto dto)
        {
            try
            {
                await _tagService.Update(dto);
                return Ok();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _tagService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpDelete("SoftDelete/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            try
            {
                await _tagService.SoftDelete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
    }
}
