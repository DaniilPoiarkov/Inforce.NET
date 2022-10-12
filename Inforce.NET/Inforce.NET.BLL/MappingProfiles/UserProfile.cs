using AutoMapper;
using Inforce.NET.Common.DTOs;
using Inforce.NET.Common.Entities;

namespace Inforce.NET.BLL.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
