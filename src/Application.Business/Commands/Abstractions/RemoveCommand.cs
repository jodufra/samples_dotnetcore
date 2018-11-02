using MediatR;

namespace Application.Business.Commands.Abstractions
{
    public abstract class RemoveCommand : IRequest
    {
        public int Id { get; set; }
    }
}
