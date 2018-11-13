using Application.Business.Exceptions;
using Application.Business.Interfaces;
using Application.Domain.Entities;
using AutoMapper;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Business.Services.Enrollments
{
    public class UpdateEnrollmentCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UpdateEnrollmentCommandValidator : AbstractValidator<UpdateEnrollmentCommand>
    {
        public UpdateEnrollmentCommandValidator()
        {
            RuleFor(q => q.Id).GreaterThan(0);
            RuleFor(q => q.Name).NotEmpty();
        }
    }

    public class UpdateEnrollmentCommandHandler : IRequestHandler<UpdateEnrollmentCommand, Unit>
    {
        private readonly IMapper mapper;
        private readonly IRepository<Enrollment> repository;

        public UpdateEnrollmentCommandHandler(IRepository<Enrollment> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEnrollmentCommand request, CancellationToken cancellationToken)
        {
            var entity = await repository.FindByIdAsync(request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(typeof(Enrollment).Name, request.Id);
            }

            entity = mapper.Map(request, entity);

            await repository.UpdateAsync(entity, true, cancellationToken);

            return Unit.Value;
        }
    }
}
