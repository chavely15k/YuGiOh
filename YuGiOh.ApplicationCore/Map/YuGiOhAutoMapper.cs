using AutoMapper;
using YuGiOh.Domain.Models;
using YuGiOh.ApplicationCore.DTO;

namespace YuGiOh.ApplicationCore.Map {
    public class YuGiOhAutoMapper {
        public YuGiOhAutoMapper() {
            //var config = new MapperConfiguration
        CreateMap<RegisterUserRequest, User>()
            .ForMember(dto => dto.Name, ent => ent.MapFrom(src => src.Name))
            .ForMember(dto => dto.Nick, ent => ent.MapFrom(src => src.Nick))
            .ForMember(dto => dto.Password, ent => ent.MapFrom(src => src.Password))
            .ForMember(dto => dto.Province, ent => ent.MapFrom(src => src.Province))
            .ForMember(dto => dto.Township, ent => ent.MapFrom(src => src.Township))
            .ForMember(dto => dto.Address, ent => ent.MapFrom(src => src.Address))
            .ForMember(dto => dto.PhoneNumber, ent => ent.MapFrom(src => src.PhoneNumber));

        }
    }
}
