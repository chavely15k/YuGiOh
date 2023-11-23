// using AutoMapper;
// using YuGiOh.Domain.Models;
// using YuGiOh.ApplicationCore.DTO;

// namespace YuGiOh.ApplicationCore.Map {
//     public class YuGiOhAutoMapper {
//         public YuGiOhAutoMapperP() {
            
//         CreateMap<User, RegisterUserRequest>()
//             .ForMember(dto => dto.Id, ent => ent.MapFrom(src => src.Id))
//             .ForMember(dto => dto.Name, ent => ent.MapFrom(src => src.Name))
//             .ForMember(dto => dto.ProvinceId, ent => ent.MapFrom(src => src.Province.Id));

//         }
//     }
// }