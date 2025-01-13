using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskVeren.Business.DTOs.Topic;
using TaskVeren.Business.Services.Interfaces;

namespace TaskVeren.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        readonly ITopicService _TopicService;

        public TopicController(ITopicService TopicService)
        {
            _TopicService = TopicService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _TopicService.GetById(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] CreateTopicDto dto)
        {
            try
            {
                return Ok(await _TopicService.CreateAsync(dto));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, ex.Message);
            }

        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateTopicDto dto)
        {
            try
            {
                await _TopicService.Update(dto);
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
                await _TopicService.Delete(id);
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
                await _TopicService.SoftDelete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
    }
}
