using Application.Business.Exceptions;
using Application.Business.Interfaces;
using Application.Domain.Entities;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Business.Services.Departments
{
    public class DeleteDepartmentCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteDepartmentCommandValidator : AbstractValidator<DeleteDepartmentCommand>
    {
        public DeleteDepartmentCommandValidator()
        {
            RuleFor(q => q.Id).GreaterThan(0);
        }
    }

    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand>
    {
        private readonly IRepository<Department> repository;

        public DeleteDepartmentCommandHandler(IRepository<Department> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var entity = await repository.FindByIdAsync(request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(typeof(Department).Name, request.Id);
            }

            await repository.RemoveAsync(entity, true, cancellationToken);

            return Unit.Value;
        }
    }
}
