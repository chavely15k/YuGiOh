using AutoMapper;
using YuGiOh.ApplicationCore.DTO;
using YuGiOh.Domain.Models;

namespace YuGiOh.Infrastructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterUserDto, User>()
            .ForMember(dest => dest.Roles,opt => opt.Ignore());

            CreateMap<User, RegisterUserDto>()
            .ForMember(dest => dest.Code,opt => opt.Ignore())
            .ForMember(dest => dest.Roles, opt => opt.Ignore());
        }
    }
}