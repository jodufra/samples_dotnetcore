using Application.Business.Interfaces;
using Application.Domain.Entities;
using AutoMapper;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Business.Requests.Departments
{
    public class CreateDepartmentCommand : IRequest<int>
    {
        public string Name { get; set; }
    }

    public class CreateDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommand>
    {
        public CreateDepartmentCommandValidator()
        {
            RuleFor(q => q.Name).NotEmpty();
        }
    }

    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, int>
    {
        private readonly IMapper mapper;
        private readonly IRepository<Department> repository;

        public CreateDepartmentCommandHandler(IRepository<Department> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<int> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<CreateDepartmentCommand, Department>(request);

            await repository.AddAsync(entity, cancellationToken);

            return entity.Id;
        }
    }
}
