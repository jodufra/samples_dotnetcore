using Application.Business.Requests.Abstractions;
using Application.Domain.Enumerations;

namespace Application.Business.Requests.Users
{
    public class UserDetailModel : DetailModel
    {
        public int AccountId { get; set; }
        public string Name { get; set; }
        public UserType Type { get; set; }
    }
}
