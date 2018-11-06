using Application.Business.Interfaces;
using Application.Business.Requests.Abstractions;
using Application.Domain.Entities;
using FluentValidation;

namespace Application.Business.Requests.Departments
{
    public class UpdateDepartmentCommand : UpdateCommand
    {
        public string Name { get; set; }
    }

    public class UpdateDepartmentCommandValidator : UpdateCommandValidator<UpdateDepartmentCommand>
    {
        public UpdateDepartmentCommandValidator()
        {
            RuleFor(q => q.Name).NotEmpty();
        }
    }

    public class UpdateDepartmentCommandHandler : UpdateCommandHandler<UpdateDepartmentCommand, Department>
    {
        public UpdateDepartmentCommandHandler(IRepository<Department> repository) : base(repository)
        {
        }
    }
}
