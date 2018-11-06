using Application.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Application.Persistence.Infrastructure
{
    public class DesignTimeDirectory : IDirectory
    {
        public string BaseDirectory => Directory.GetCurrentDirectory() + string.Format("{0}..{0}Application.Website", Path.DirectorySeparatorChar);
    }
}
