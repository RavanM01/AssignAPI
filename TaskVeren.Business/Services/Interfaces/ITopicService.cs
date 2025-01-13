using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskVeren.Business.DTOs.Tag;
using TaskVeren.Business.DTOs.Topic;

namespace TaskVeren.Business.Services.Interfaces
{
    public interface ITopicService
    {
        Task<GetTopicDto> CreateAsync(CreateTopicDto dto);
        Task<GetTopicDto> GetById(int id);
        List<GetTopicDto> GetAll();
        Task Update(UpdateTopicDto dto);
        Task Delete(int id);
        Task SoftDelete(int id);
    }
}
