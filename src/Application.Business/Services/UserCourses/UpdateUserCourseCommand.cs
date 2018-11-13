using Application.Business.Exceptions;
using Application.Business.Interfaces;
using Application.Domain.Entities;
using AutoMapper;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Business.Services.UserCourses
{
    public class UpdateUserCourseCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UpdateUserCourseCommandValidator : AbstractValidator<UpdateUserCourseCommand>
    {
        public UpdateUserCourseCommandValidator()
        {
            RuleFor(q => q.Id).GreaterThan(0);
            RuleFor(q => q.Name).NotEmpty();
        }
    }

    public class UpdateUserCourseCommandHandler : IRequestHandler<UpdateUserCourseCommand, Unit>
    {
        private readonly IMapper mapper;
        private readonly IRepository<UserCourse> repository;

        public UpdateUserCourseCommandHandler(IRepository<UserCourse> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateUserCourseCommand request, CancellationToken cancellationToken)
        {
            var entity = await repository.FindByIdAsync(request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(typeof(UserCourse).Name, request.Id);
            }

            entity = mapper.Map(request, entity);

            await repository.UpdateAsync(entity, true, cancellationToken);

            return Unit.Value;
        }
    }
}
