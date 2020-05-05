using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dependency_injection_demo.Middleware.Config
{
    public class ApplicationSettings
    {
        public string EnvironmentName { get; set; }
        public ApplicationInfo ApplicationInfo { get; set; }
    }
}
