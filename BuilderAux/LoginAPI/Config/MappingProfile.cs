//using AutoMapper;
//using LoginAPI.ValuesObjects;
//using Microsoft.AspNetCore.Identity;
////sem uso, apenas possivel referencia
//public class MappingProfile : Profile
//{
//    public MappingProfile()
//    {
//        CreateMap<IdentityUser, UserVOIn>()
//            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.UserName))
//            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
//            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.PhoneNumber))
//            // Mapeie outras propriedades conforme necessário
//            .ReverseMap(); // Se você deseja mapeamento bidirecional
//    }
//}
