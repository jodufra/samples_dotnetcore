using Application.Business.Infrastructure;
using Application.Business.Queries.Abstractions;
using Application.Domain.Entities;

namespace Application.Business.Queries.Users
{
    public class UserDetailQueryHandler : DetailQueryHandler<UserDetailQuery, UserDetailModel, User>
    {
        public UserDetailQueryHandler(IReadOnlyRepository<User> repository) : base(repository)
        {
        }
    }
}
