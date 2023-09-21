using AutoMapper;
using LoginAPI.Models;
using LoginAPI.ValuesObjects;
using Microsoft.AspNetCore.Identity;

namespace LoginAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<UserVOIn, UserModel>();
                config.CreateMap<UserModel, UserVOIn>();
                config.CreateMap<IdentityUser, UserVOIn>();
                config.CreateMap<UserVOIn, IdentityUser>();
                config.CreateMap<UserVOIn, UserVOOut>();
                config.CreateMap<UserVOOut, UserVOIn>();

            });
        }
    }
}
