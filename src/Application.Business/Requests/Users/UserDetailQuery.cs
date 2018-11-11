using Application.Business.Exceptions;
using Application.Business.Interfaces;
using Application.Domain.Entities;
using Application.Domain.Enumerations;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Business.Requests.Users
{
    public class UserDetailModel
    {
        public int Id { get; set; }
        public int EntityId { get; set; }
        public string Name { get; set; }
        public UserType Type { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdate { get; set; }
    }

    public class UserDetailQuery : IRequest<UserDetailModel>
    {
        public int Id { get; set; }
    }

    public class UserDetailQueryValidator : AbstractValidator<UserDetailModel>
    {
        public UserDetailQueryValidator()
        {
            RuleFor(q => q.Id).GreaterThan(0);
        }
    }

    public class UserDetailQueryHandler : IRequestHandler<UserDetailQuery, UserDetailModel>
    {
        private readonly IMapper mapper;
        private readonly IReadOnlyRepository<User> repository;

        public UserDetailQueryHandler(IReadOnlyRepository<User> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<UserDetailModel> Handle(UserDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await repository.FindByIdAsync(request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(typeof(User).Name, request.Id);
            }

            return mapper.Map<User, UserDetailModel>(entity);
        }
    }
}
