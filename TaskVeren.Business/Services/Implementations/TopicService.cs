using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskVeren.Business.DTOs.Topic;
using TaskVeren.Business.DTOs.Topic;
using TaskVeren.Business.Services.Interfaces;
using TaskVeren.Core.Entities;
using TaskVeren.DAL.Repositories.Interfaces;

namespace TaskVeren.Business.Services.Implementations
{
    public class TopicService : ITopicService
    {
        readonly ITopicRepository _repo;
        readonly IMapper _mapper;

        public TopicService(IMapper mapper, ITopicRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<GetTopicDto> CreateAsync(CreateTopicDto dto)
        {
            if (await _repo.IsExsist(x => x.Name == dto.Name))
            {
                throw new Exception("Olmaz");
            }
            var model = _mapper.Map<Topic>(dto);
            var newModel = await _repo.Create(model);
            await _repo.SaveChangesAsync();
            return _mapper.Map<GetTopicDto>(newModel);
        }

        public async Task Delete(int id)
        {
            var Topic = await GetById(id);
            _repo.Delete(_mapper.Map<Topic>(Topic));
            await _repo.SaveChangesAsync();
        }

        public List<GetTopicDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<GetTopicDto> GetById(int id)
        {
            if (id <= 0)
            {
                throw new Exception();
            }
            GetTopicDto dto = _mapper.Map<GetTopicDto>(await _repo.GetbyId(id));

            return dto != null ? dto : throw new Exception();
        }

        public async Task SoftDelete(int id)
        {

            var Topic = await GetById(id);
            _repo.SoftDelete(_mapper.Map<Topic>(Topic));
            await _repo.SaveChangesAsync();
        }

        public async Task Update(UpdateTopicDto dto)
        {
            var oldTopic = await GetById(dto.Id);
            if (await _repo.IsExsist(c => c.Name == dto.Name))
            {
                throw new Exception();
            }
            oldTopic = _mapper.Map<GetTopicDto>(dto);
            _repo.Update(_mapper.Map<Topic>(oldTopic));
            await _repo.SaveChangesAsync();
        }
    }
}
