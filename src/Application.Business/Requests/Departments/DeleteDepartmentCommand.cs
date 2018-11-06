using Application.Business.Interfaces;
using Application.Business.Requests.Abstractions;
using Application.Domain.Entities;
using FluentValidation;

namespace Application.Business.Requests.Departments
{
    public class DeleteDepartmentCommand : DeleteCommand
    {
    }

    public class DeleteDepartmentCommandValidator : DeleteCommandValidator<DeleteDepartmentCommand>
    {
    }

    public class DeleteDepartmentCommandHandler : DeleteCommandHandler<DeleteDepartmentCommand, Department>
    {
        public DeleteDepartmentCommandHandler(IRepository<Department> repository) : base(repository)
        {
        }
    }
}
