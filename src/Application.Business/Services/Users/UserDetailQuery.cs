using Application.Business.Exceptions;
using Application.Business.Interfaces;
using Application.Domain.Entities;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Business.Services.Users
{
    public class UserDetailModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserType UserType { get; set; }
        public Address Address { get; set; }
        public Phone Cellphone { get; set; }
        public Phone Telephone { get; set; }
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
