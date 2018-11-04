using Application.Business.Infrastructure;
using Application.Business.Requests.Abstractions;
using Application.Domain.Entities;

namespace Application.Business.Requests.Users
{
    public class UsersListQueryHandler : ListQueryHandler<UsersListQuery, UsersListModel, UsersListItemModel, User>
    {
        public UsersListQueryHandler(IReadOnlyRepository<User> repository) : base(repository)
        {
        }

        public override RepositoryRequest<User> BuildRepositoryRequest(UsersListQuery request)
        {
            var repositoryRequest = base.BuildRepositoryRequest(request);

            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                repositoryRequest.Query.Where(q => q.Name.Contains(request.Search));
            }

            return repositoryRequest;
        }
    }
}
