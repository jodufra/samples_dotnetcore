using Application.Business.Exceptions;
using Application.Business.Interfaces;
using Application.Domain.Entities;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Business.Requests.Enrollments
{
    public class EnrollmentDetailModel 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdate { get; set; }
    }

    public class EnrollmentDetailQuery : IRequest<EnrollmentDetailModel>
    {
        public int Id { get; set; }
    }

    public class EnrollmentDetailQueryValidator : AbstractValidator<EnrollmentDetailModel>
    {
        public EnrollmentDetailQueryValidator()
        {
            RuleFor(q => q.Id).GreaterThan(0);
        }
    }

    public class EnrollmentDetailQueryHandler : IRequestHandler<EnrollmentDetailQuery, EnrollmentDetailModel>
    {
        private readonly IMapper mapper;
        private readonly IReadOnlyRepository<Enrollment> repository;

        public EnrollmentDetailQueryHandler(IReadOnlyRepository<Enrollment> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<EnrollmentDetailModel> Handle(EnrollmentDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await repository.FindByIdAsync(request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(typeof(Enrollment).Name, request.Id);
            }

            return mapper.Map<Enrollment, EnrollmentDetailModel>(entity);
        }
    }
}
