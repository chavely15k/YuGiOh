using AutoMapper;
using YuGiOh.ApplicationCore.DTO;
using YuGiOh.ApplicationServices.Service;
using YuGiOh.Domain.Models;
using YuGiOh.Infrastructure.Service;

namespace YuGiOh.Infrastructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile(IUserService userService)
        {
            CreateMap<RegisterUserDto, User>()
                .ForMember(dest => dest.Roles, opt => opt.Ignore());

            CreateMap<User, RegisterUserDto>()
                .ForMember(dest => dest.Code, opt => opt.Ignore())
                .ForMember(dest => dest.Roles, opt => opt.Ignore());

            CreateMap<RegisterDeckDto, Deck>()
                .ForMember(dest => dest.Player, opt => opt.Ignore())
                .AfterMap(async (src, dest) =>
                {
                    dest.Player = await userService.GetUserByIdAsync(src.PalyerId);
                });
             CreateMap<Deck, RegisterDeckDto>()
            .ForMember(dest => dest.PalyerId, opt => opt.MapFrom(src => src.Player.Id));
            
        }
    }
}