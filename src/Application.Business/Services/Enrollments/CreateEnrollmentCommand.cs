using Application.Business.Interfaces;
using Application.Domain.Entities;
using AutoMapper;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Business.Services.Enrollments
{
    public class CreateEnrollmentCommand : IRequest<int>
    {
        public string Name { get; set; }
    }

    public class CreateEnrollmentCommandValidator : AbstractValidator<CreateEnrollmentCommand>
    {
        public CreateEnrollmentCommandValidator()
        {
            RuleFor(q => q.Name).NotEmpty();
        }
    }

    public class CreateEnrollmentCommandHandler : IRequestHandler<CreateEnrollmentCommand, int>
    {
        private readonly IMapper mapper;
        private readonly IRepository<Enrollment> repository;

        public CreateEnrollmentCommandHandler(IRepository<Enrollment> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<int> Handle(CreateEnrollmentCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<CreateEnrollmentCommand, Enrollment>(request);

            await repository.AddAsync(entity, true, cancellationToken);

            return entity.Id;
        }
    }
}
