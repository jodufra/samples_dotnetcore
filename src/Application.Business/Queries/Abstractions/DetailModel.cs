using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Business.Queries.Abstractions
{
    public abstract class DetailModel
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdate { get; set; }
    }
}
