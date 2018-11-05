using Application.Business.Requests.Entities;
using Application.Business.Requests.Users;
using Application.Domain.Entities;
using AutoMapper;

namespace Application.Business
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            // Entities
            CreateMap<CreateEntityCommand, Entity>();
            CreateMap<UpdateEntityCommand, Entity>();
            CreateMap<Entity, EntityDetailModel>();
            CreateMap<Entity, EntitiesListItemModel>();

            // Users
            CreateMap<CreateUserCommand, User>();
            CreateMap<UpdateUserCommand, User>();
            CreateMap<User, UserDetailModel>();
            CreateMap<User, UsersListItemModel>();
        }
    }
}
