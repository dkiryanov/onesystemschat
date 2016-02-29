using AutoMapper;
using BLL.DTO;
using OneSystemsChat.Models;
using OneSystemsChat.Models.Message;
using OneSystemsChat.Models.User;

namespace OneSystemsChat.App_Start
{
    public static class AutomapperConfig
    {
        public static void RegisterMappings()
        {
            RegisterUserMappings();
            RegisterMessageMappings();
        }

        private static void RegisterUserMappings()
        {
            Mapper.CreateMap<UserRegisterModel, UserDto>();

            Mapper.CreateMap<UserViewModel, UserDto>();
            Mapper.CreateMap<UserDto, UserViewModel>();
        }

        private static void RegisterMessageMappings()
        {
            Mapper.CreateMap<MessageViewModel, MessageDto>();

            Mapper.CreateMap<MessageDto, MessageViewModel>()
                .ForMember(dest => dest.Login, opts => opts.MapFrom(src => src.User.Login));

            Mapper.CreateMap<MessageCreateModel, MessageDto>();
        }
    }
}