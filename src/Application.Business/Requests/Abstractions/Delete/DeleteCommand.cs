using MediatR;

namespace Application.Business.Requests.Abstractions
{
    public abstract class DeleteCommand : IRequest
    {
        public int Id { get; set; }
    }
}
