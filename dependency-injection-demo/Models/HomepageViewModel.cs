using dependency_injection_demo.Middleware.Config;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dependency_injection_demo.Models
{
    public class HomepageViewModel
    {
        public ApplicationSettings applicationSettings { get; set; }
        public IConfiguration config { get; set; }
    }
}
