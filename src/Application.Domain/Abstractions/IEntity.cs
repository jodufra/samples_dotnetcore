using System;

namespace Application.Domain.Abstractions
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime DateCreated { get; set; }
        DateTime? DateUpdated { get; set; }
    }
}
