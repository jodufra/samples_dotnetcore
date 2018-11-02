using Application.Business.Commands.Users;
using Application.Domain.Entities;
using AutoMapper;

namespace Application.Business
{
    public static class AutoMapperConfiguration
    {
        public static void Apply(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<CreateUserCommand, User>();
            cfg.CreateMap<UpdateUserCommand, User>();
        }
    }
}
