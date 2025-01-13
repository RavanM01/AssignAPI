using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskVeren.Business.DTOs.Assignment;
using TaskVeren.Business.DTOs.Tag;
using TaskVeren.Business.Services.Interfaces;
using TaskVeren.Core.Entities;
using TaskVeren.DAL.Repositories.Interfaces;

namespace TaskVeren.Business.Services.Implementations
{
    public class AssignmentService : IAssignmentService
    {
        readonly IAssingmentRepository _repo;
        readonly IMapper _mapper;

        public AssignmentService(IMapper mapper, IAssingmentRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<GetAssignmentDto> CreateAsync(CreateAssignmentDto dto, string userId)
        {
            if (await _repo.IsExsist(x => x.Title == dto.Title))
            {
                throw new Exception("Olmaz");
            }

            var model = _mapper.Map<Assignment>(dto);
            
            model.AppUserId = userId;
            

            var newModel = await _repo.Create(model);
            await _repo.SaveChangesAsync();
            return _mapper.Map<GetAssignmentDto>(newModel);
        }

        public List<GetAssignmentDto> GetAll(string userId)
        {
            List<GetAssignmentDto> dtos = new();
            var datas=_repo.GetAll();
            
            foreach (var data in datas)
            {
                if (data.AppUserId == userId)
                {
                GetAssignmentDto dto = _mapper.Map<GetAssignmentDto>(data);
                dtos.Add(dto);
                }
            }
            return dtos;
        }

        public async Task<GetAssignmentDto> GetById(int id)
        {
            if (id <= 0)
            {
                throw new Exception();
            }
            GetAssignmentDto dto = _mapper.Map<GetAssignmentDto>(await _repo.GetbyId(id));

            return dto != null ? dto : throw new Exception();
        }
    }
}
