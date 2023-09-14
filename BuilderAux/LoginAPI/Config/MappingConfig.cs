using AutoMapper;
using LoginAPI.Models;
using LoginAPI.ValuesObjects;

namespace LoginAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<UserVO, UserModel>();
                config.CreateMap<UserModel, UserVO>();

            });
        }
    }
}
