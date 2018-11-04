﻿using Application.Business.Requests.Abstractions;
using Application.Business.Infrastructure;
using Application.Domain.Entities;

namespace Application.Business.Requests.Users
{
    public class UpdateUserCommandHandler : UpdateCommandHandler<UpdateUserCommand, User>
    {
        public UpdateUserCommandHandler(IRepository<User> repository) : base(repository)
        {
        }
    }
}