using MediatR;

namespace Application.Business.Commands.Abstractions
{
    public abstract class UpdateCommand : IRequest
    {
        public int Id { get; set; }
    }
}
