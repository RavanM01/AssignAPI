using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskVeren.Business.DTOs.Assignment;
using TaskVeren.Business.DTOs.Tag;
using TaskVeren.Business.Services.Implementations;
using TaskVeren.Business.Services.Interfaces;

namespace TaskVeren.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AssignmentController : ControllerBase
    {
        readonly IAssignmentService _assignmentService;

        public AssignmentController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _assignmentService.GetById(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
        [HttpGet()]
        public IActionResult GetAll()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return Ok(_assignmentService.GetAll(userId));
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] CreateAssignmentDto dto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            try
            {
                return Ok(await _assignmentService.CreateAsync(dto,userId));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, ex.Message);
            }

        }
    }
}
