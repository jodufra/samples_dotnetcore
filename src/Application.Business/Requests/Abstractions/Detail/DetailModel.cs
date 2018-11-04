using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Business.Requests.Abstractions
{
    public abstract class DetailModel
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdate { get; set; }
    }
}
