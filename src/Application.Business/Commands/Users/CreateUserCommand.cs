using Application.Business.Commands.Abstractions;
using Application.Domain.Enumerations;

namespace Application.Business.Commands.Users
{
    public class CreateUserCommand : CreateCommand
    {
        public int AccountId { get; set; }
        public string Name { get; set; }
        public UserType Type { get; set; }
    }
}
