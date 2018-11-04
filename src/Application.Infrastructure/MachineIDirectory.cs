using Application.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Infrastructure
{
    public class MachineIDirectory : IDirectory
    {
        public string BaseDirectory => AppDomain.CurrentDomain.BaseDirectory;
    }
}
