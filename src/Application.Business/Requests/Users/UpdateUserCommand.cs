using Application.Business.Exceptions;
using Application.Business.Interfaces;
using Application.Domain.Entities;
using Application.Domain.Enumerations;
using AutoMapper;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Business.Requests.Users
{
    public class UpdateUserCommand : IRequest
    {
        public int Id { get; set; }
        public int EntityId { get; set; }
        public string Name { get; set; }
        public UserType Type { get; set; }
    }

    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(q => q.Id).GreaterThan(0);
            RuleFor(q => q.EntityId).GreaterThan(0);
            RuleFor(q => q.Name).NotEmpty();
        }
    }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IMapper mapper;
        private readonly IRepository<User> repository;

        public UpdateUserCommandHandler(IRepository<User> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await repository.FindByIdAsync(request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(typeof(User).Name, request.Id);
            }

            entity = mapper.Map(request, entity);

            await repository.UpdateAsync(entity, true, cancellationToken);

            return Unit.Value;
        }
    }
}
