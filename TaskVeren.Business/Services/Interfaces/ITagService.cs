using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskVeren.Business.DTOs.Tag;

namespace TaskVeren.Business.Services.Interfaces
{
    public interface ITagService
    {
        Task<GetTagDto> CreateAsync(CreateTagDto dto);
        Task<GetTagDto> GetById(int id);
        List<GetTagDto> GetAll();
        Task Update(UpdateTagDto dto);
        Task Delete(int id);
        Task SoftDelete(int id);
    }
}
