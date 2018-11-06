using Application.Business.Interfaces;
using Application.Business.Requests.Abstractions;
using Application.Domain.Entities;

namespace Application.Business.Requests.Enrollments
{
    public class EnrollmentDetailModel : DetailModel
    {
        public string Name { get; set; }
    }

    public class EnrollmentDetailQuery : DetailQuery<EnrollmentDetailModel>
    {
    }

    public class EnrollmentDetailQueryValidator : DetailQueryValidator<EnrollmentDetailQuery, EnrollmentDetailModel>
    {
    }

    public class EnrollmentDetailQueryHandler : DetailQueryHandler<EnrollmentDetailQuery, EnrollmentDetailModel, Enrollment>
    {
        public EnrollmentDetailQueryHandler(IReadOnlyRepository<Enrollment> repository) : base(repository)
        {
        }
    }
}
