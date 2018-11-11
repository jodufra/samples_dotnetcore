using Application.Business.Exceptions;
using Application.Business.Interfaces;
using Application.Domain.Entities;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Business.Requests.Departments
{
    public class DepartmentDetailModel 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdate { get; set; }
    }

    public class DepartmentDetailQuery : IRequest<DepartmentDetailModel>
    {
        public int Id { get; set; }
    }

    public class DepartmentDetailQueryValidator : AbstractValidator<DepartmentDetailModel>
    {
        public DepartmentDetailQueryValidator()
        {
            RuleFor(q => q.Id).GreaterThan(0);
        }
    }

    public class DepartmentDetailQueryHandler : IRequestHandler<DepartmentDetailQuery, DepartmentDetailModel>
    {
        private readonly IMapper mapper;
        private readonly IReadOnlyRepository<Department> repository;

        public DepartmentDetailQueryHandler(IReadOnlyRepository<Department> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<DepartmentDetailModel> Handle(DepartmentDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await repository.FindByIdAsync(request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(typeof(Department).Name, request.Id);
            }

            return mapper.Map<Department, DepartmentDetailModel>(entity);
        }
    }
}
