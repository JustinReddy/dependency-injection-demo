using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dependency_injection_demo.Models
{
    public class LifetimeTestModel
    {
        public Guid id { get; set; }
        public string description { get; set; }
    }
}
