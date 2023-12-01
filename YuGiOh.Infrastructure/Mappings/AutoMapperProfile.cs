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
                .ForMember(dest => dest.User, opt => opt.Ignore());
                //.ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => (src.StartDate + "Z")));

            CreateMap<Tournament, TournamentDto>()
                .ForMember(dest => dest.AdminId, opt => opt.MapFrom(src => src.User.Id));
            
            CreateMap<Request, RequestDto>()
                .ForMember(dest => dest.Status, opt => opt.Ignore());

            CreateMap<RequestDto,Request>()
                .ForMember(dest => dest.Date, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore());

            CreateMap<MatchDto,Match>()
                .ForMember(dest => dest.PlayerOneId, ent => ent.MapFrom(src => src.PlayerOneId))
                .ForMember(dest => dest.PlayerTwoId, ent => ent.MapFrom(src => src.PlayerTwoId))
                .ForMember(dest => dest.Date, ent => ent.MapFrom(src => src.Date))
                .ForMember(dest => dest.TournamentId, ent => ent.MapFrom(src => src.TournamentId))
                .ForMember(dest => dest.PlayerOneResult, ent => ent.MapFrom(src => src.PlayerOneResult))
                .ForMember(dest => dest.PlayerTwoResult, ent => ent.MapFrom(src => src.PlayerTwoResult))
                .ForMember(dest => dest.Round, ent => ent.MapFrom(src => src.Round))
                .ForMember(dest => dest.Group, ent => ent.MapFrom(src => src.Group));

            CreateMap<Match,MatchDto>()
                .ForMember(dest => dest.PlayerOneId, ent => ent.MapFrom(src => src.PlayerOneId))
                .ForMember(dest => dest.PlayerTwoId, ent => ent.MapFrom(src => src.PlayerTwoId))
                .ForMember(dest => dest.Date, ent => ent.MapFrom(src => src.Date))
                .ForMember(dest => dest.TournamentId, ent => ent.MapFrom(src => src.TournamentId))
                .ForMember(dest => dest.PlayerOneResult, ent => ent.MapFrom(src => src.PlayerOneResult))
                .ForMember(dest => dest.PlayerTwoResult, ent => ent.MapFrom(src => src.PlayerTwoResult))
                .ForMember(dest => dest.Round, ent => ent.MapFrom(src => src.Round))
                .ForMember(dest => dest.Group, ent => ent.MapFrom(src => src.Group));
        }
    }
}