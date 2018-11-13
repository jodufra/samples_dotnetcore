using Application.Business.Events;
using Application.Business.Interfaces;
using Application.Domain.Entities;
using Application.Domain.SeedWork;
using AutoMapper;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Business.Services.Users
{
    public class CreateUserCommand : IRequest<int>
    {
        public int UserTypeId { get; set; }
        public string Name { get; set; }
    }

    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(q => q.UserTypeId).Must(q => Enumeration.FromValue<UserType>(q) != null);
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

            entity.AddDomainEvent(new UserCreatedEvent(entity));

            await repository.AddAsync(entity, true, cancellationToken);

            return entity.Id;
        }
    }
}
