using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dependency_injection_demo.Models
{
    public class LifetimeTestViewModel
    {
        public string TransientDescription { get; set; }
        public string ScopedDescription { get; set; }
        public string SingletonDescription { get; set; }
    }
}
