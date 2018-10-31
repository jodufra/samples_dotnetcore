using System;
using Application.Common;

namespace Application.Infrastructure
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
