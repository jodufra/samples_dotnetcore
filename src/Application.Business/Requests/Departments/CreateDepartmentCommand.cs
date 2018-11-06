using Application.Business.Interfaces;
using Application.Business.Requests.Abstractions;
using Application.Domain.Entities;
using FluentValidation;

namespace Application.Business.Requests.Departments
{
    public class CreateDepartmentCommand : CreateCommand
    {
        public string Name { get; set; }
    }

    public class CreateDepartmentCommandValidator : CreateCommandValidator<CreateDepartmentCommand>
    {
        public CreateDepartmentCommandValidator()
        {
            RuleFor(q => q.Name).NotEmpty();
        }
    }

    public class CreateDepartmentCommandHandler : CreateCommandHandler<CreateDepartmentCommand, Department>
    {
        public CreateDepartmentCommandHandler(IRepository<Department> repository) : base(repository)
        {
        }
    }
}
