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
                .ForMember(dest => dest.ArchetypeId, opt => opt.MapFrom(src => src.Archetype.Id))
                .ForMember(dest => dest.PlayerId, opt => opt.MapFrom(src => src.Player.Id))
                .ForMember(dest => dest.ArchetypeName, opt => opt.MapFrom(src => src.Archetype.Name));

            CreateMap<TournamentDto, Tournament>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.AdminId))
                .ForMember(dest => dest.User, opt => opt.Ignore());
                //.ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => (src.StartDate + "Z")));

            CreateMap<Tournament, TournamentDto>()
                .ForMember(dest => dest.AdminId, opt => opt.MapFrom(src => src.User.Id));
            
            CreateMap<Tournament, ResponseTournamentDto>()
                .ForMember(dest => dest.AdminId, opt => opt.MapFrom(src => src.User.Id))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate.Date.ToString()));
            
            CreateMap<Request, ResponseRequestDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.Date.ToString()));
            
            CreateMap<Request, RequestDto>()
                .ForMember(dest => dest.Status, opt => opt.Ignore());

            CreateMap<RequestDto,Request>()
                .ForMember(dest => dest.Date, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore());

            CreateMap<ArchetypeDto,Archetype>()
                .ForMember(dest => dest.Id , opt => opt.Ignore());

            CreateMap<Archetype,ArchetypeDto>();
               
            CreateMap<Match, MatchResultDto>();
            CreateMap<MatchResultDto, Match>();

            CreateMap<MatchDto,Match>();
            CreateMap<Match,MatchDto>();
        }
    }
}