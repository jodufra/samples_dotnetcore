using MediatR;

namespace Application.Business.Requests.Abstractions
{
    public abstract class UpdateCommand : IRequest
    {
        public int Id { get; set; }
    }
}
