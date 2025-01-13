using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskVeren.Business.DTOs.Tag;
using TaskVeren.Business.Services.Interfaces;
using TaskVeren.Core.Entities;
using TaskVeren.DAL.Repositories.Interfaces;

namespace TaskVeren.Business.Services.Implementations
{
    public class TagService:ITagService
    {
        readonly ITagRepository _repo;
        readonly IMapper _mapper;

        public TagService(IMapper mapper, ITagRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<GetTagDto> CreateAsync(CreateTagDto dto)
        {
            if (await _repo.IsExsist(x => x.Name == dto.Name))
            {
                throw new Exception("Olmaz");
            }
            var model = _mapper.Map<Tag>(dto);
            var newModel = await _repo.Create(model);
            await _repo.SaveChangesAsync();
            return _mapper.Map<GetTagDto>(newModel);
        }

        public async Task Delete(int id)
        {
            var Tag = await GetById(id);
            _repo.Delete(_mapper.Map<Tag>(Tag));
            await _repo.SaveChangesAsync();
        }

        public List<GetTagDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<GetTagDto> GetById(int id)
        {
            if (id <= 0)
            {
                throw new Exception();
            }
            GetTagDto dto = _mapper.Map<GetTagDto>(await _repo.GetbyId(id));

            return dto != null ? dto : throw new Exception();
        }

        public async Task SoftDelete(int id)
        {
            var Tag = await GetById(id);
            _repo.SoftDelete(_mapper.Map<Tag>(Tag));
            await _repo.SaveChangesAsync();
        }

        public async Task Update(UpdateTagDto dto)
        {
            var oldTag = await GetById(dto.Id);
            if (await _repo.IsExsist(c => c.Name == dto.Name))
            {
                throw new Exception();
            }
            oldTag = _mapper.Map<GetTagDto>(dto);
            _repo.Update(_mapper.Map<Tag>(oldTag));
            await _repo.SaveChangesAsync();
        }
    }
}
