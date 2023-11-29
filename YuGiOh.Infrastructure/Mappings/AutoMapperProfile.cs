using System.Net.Security;
using AutoMapper;
using YuGiOh.ApplicationCore.DTO;
using YuGiOh.ApplicationServices.Service;
using YuGiOh.Domain.Models;
using YuGiOh.Infrastructure.Service;

namespace YuGiOh.Infrastructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDto, User>()
                .ForMember(dest => dest.Roles, opt => opt.Ignore());

            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Code, opt => opt.Ignore())
                .ForMember(dest => dest.Roles, opt => opt.Ignore());

            CreateMap<DeckDto, Deck>()
                .ForMember(dest => dest.Archetype, opt => opt.Ignore())
                .ForMember(dest => dest.Player, opt => opt.Ignore());
   
            CreateMap<Deck, DeckDto>()
                .ForMember(dest => dest.Archetype, opt => opt.Ignore())
                .ForMember(dest => dest.PalyerId, opt => opt.MapFrom(src => src.Player.Id));
                
            
            CreateMap<TournamentDto, Tournament>()
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => (src.StartDate + "Z")));

            CreateMap<Tournament, TournamentDto>()
                .ForMember(dest => dest.AdminId, opt => opt.MapFrom(src => src.User.Id));
            
            CreateMap<Request, RequestDto>()
                .ForMember(dest => dest.Status, opt => opt.Ignore());

            CreateMap<RequestDto,Request>()
                .ForMember(dest => dest.Date, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore());
        }
    }
}