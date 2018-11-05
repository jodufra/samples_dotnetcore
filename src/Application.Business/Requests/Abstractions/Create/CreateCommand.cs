using MediatR;

namespace Application.Business.Requests.Abstractions
{
    public abstract class CreateCommand : IRequest
    {
        protected CreateCommand()
        {
        }
    }
}
