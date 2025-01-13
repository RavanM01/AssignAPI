using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskVeren.Business.DTOs.Assignment;
using TaskVeren.Business.DTOs.Tag;
using TaskVeren.Business.DTOs.Topic;
using TaskVeren.Business.DTOs.User;
using TaskVeren.Core.Entities;

namespace TaskVeren.Business.Helpers.Mapper
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<GetTagDto, Tag>().ReverseMap();
            CreateMap<CreateTagDto, Tag>().ReverseMap();
            CreateMap<UpdateTagDto, GetTagDto>().ReverseMap();

            CreateMap<GetTopicDto, Topic>().ReverseMap();
            CreateMap<CreateTopicDto, Topic>().ReverseMap();
            CreateMap<UpdateTopicDto, GetTopicDto>().ReverseMap();


            CreateMap<CreateAssignmentDto,Assignment>().ForMember(dest => dest.AppUserId, opt => opt.Ignore()).ReverseMap();
            CreateMap<GetAssignmentDto,Assignment>().ReverseMap();
            CreateMap<RegisterDto, AppUser>().ReverseMap();
        }
    }
}
