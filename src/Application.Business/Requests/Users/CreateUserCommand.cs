using Application.Business.Interfaces;
using Application.Business.Notifications.Events;
using Application.Domain.Entities;
using Application.Domain.Enumerations;
using AutoMapper;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Business.Requests.Users
{
    public class CreateUserCommand : IRequest<int>
    {
        public int EntityId { get; set; }
        public string Name { get; set; }
        public UserType Type { get; set; }
    }

    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(q => q.EntityId).GreaterThan(0);
            RuleFor(q => q.Name).NotEmpty();
        }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IMapper mapper;
        private readonly IRepository<User> repository;

        public CreateUserCommandHandler(IRepository<User> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<CreateUserCommand, User>(request);

            entity.AddDomainEvent(new OnUserCreatedEvent(entity));

            await repository.AddAsync(entity, cancellationToken);

            return entity.Id;
        }
    }
}
