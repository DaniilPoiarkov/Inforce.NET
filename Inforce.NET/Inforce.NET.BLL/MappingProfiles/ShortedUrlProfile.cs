using AutoMapper;
using Inforce.NET.Common.AuxiliaryModels;
using Inforce.NET.Common.DTOs;
using Inforce.NET.Common.Entities;

namespace Inforce.NET.BLL.MappingProfiles
{
    public class ShortedUrlProfile : Profile
    {
        public ShortedUrlProfile()
        {
            CreateMap<ShortedUrl, ShortedUrlDto>().ReverseMap();
            CreateMap<NewUrl, ShortedUrl>();
        }
    }
}
