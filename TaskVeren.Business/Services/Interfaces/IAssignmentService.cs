using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskVeren.Business.DTOs.Assignment;
using TaskVeren.Business.DTOs.Tag;

namespace TaskVeren.Business.Services.Interfaces
{
    public interface IAssignmentService
    {
        Task<GetAssignmentDto> CreateAsync(CreateAssignmentDto dto, string userId);
        Task<GetAssignmentDto> GetById(int id);
        List<GetAssignmentDto> GetAll(string userId);

    }
}
