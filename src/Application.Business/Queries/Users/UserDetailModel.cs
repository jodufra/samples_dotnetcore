using Application.Business.Queries.Abstractions;
using Application.Domain.Enumerations;

namespace Application.Business.Queries.Users
{
    public class UserDetailModel : DetailModel
    {
        public int AccountId { get; set; }
        public string Name { get; set; }
        public UserType Type { get; set; }
    }
}
