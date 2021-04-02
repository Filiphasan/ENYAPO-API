using AutoMapper;
using Enyapo.Core.Dtos;
using Enyapo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enyapo.Service.Mapper
{
    class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<UserAppDto, UserApp>().ReverseMap();
            CreateMap<CreateUserAppDto, UserApp>().ReverseMap();
            CreateMap<CreateUserPostDto, UserPost>().ReverseMap();
            CreateMap<UpdateUserPostDto, UserPost>().ReverseMap();
            CreateMap<UserPostDto, UserPost>().ReverseMap();
            CreateMap<CreateActivityDto, Activity>().ReverseMap();
            CreateMap<UpdateActivityDto, Activity>().ReverseMap();
            CreateMap<ActivityDto, Activity>().ReverseMap();
        }
    }
}
