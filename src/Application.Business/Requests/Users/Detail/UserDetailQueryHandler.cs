using Application.Business.Infrastructure;
using Application.Business.Interfaces;
using Application.Business.Requests.Abstractions;
using Application.Domain.Entities;

namespace Application.Business.Requests.Users
{
    public class UserDetailQueryHandler : DetailQueryHandler<UserDetailQuery, UserDetailModel, User>
    {
        public UserDetailQueryHandler(IReadOnlyRepository<User> repository) : base(repository)
        {
        }
    }
}
