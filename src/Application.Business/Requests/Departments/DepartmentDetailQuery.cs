using Application.Business.Interfaces;
using Application.Business.Requests.Abstractions;
using Application.Domain.Entities;

namespace Application.Business.Requests.Departments
{
    public class DepartmentDetailModel : DetailModel
    {
        public string Name { get; set; }
    }

    public class DepartmentDetailQuery : DetailQuery<DepartmentDetailModel>
    {
    }

    public class DepartmentDetailQueryValidator : DetailQueryValidator<DepartmentDetailQuery, DepartmentDetailModel>
    {
    }

    public class DepartmentDetailQueryHandler : DetailQueryHandler<DepartmentDetailQuery, DepartmentDetailModel, Department>
    {
        public DepartmentDetailQueryHandler(IReadOnlyRepository<Department> repository) : base(repository)
        {
        }
    }
}
