using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL.Infrastructure
{
    public static class AutomapperBllConfig
    {
        public static void RegisterMappings()
        {
            RegisterUserMappings();
            RegisterMessageMappings();
        }

        private static void RegisterUserMappings()
        {
            Mapper.CreateMap<User, UserDto>();
            Mapper.CreateMap<UserDto, User>();
        }

        private static void RegisterMessageMappings()
        {
            Mapper.CreateMap<MessageDto, Message>();
            Mapper.CreateMap<Message, MessageDto>();
        }
    }
}
