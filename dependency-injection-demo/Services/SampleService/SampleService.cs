using System;
using System.Reflection;

namespace dependency_injection_demo.Services.SampleService
{
    public class SampleService : ISampleService
    {
        public string GetServiceInformation()
        {
            return $"{Assembly.GetExecutingAssembly().GetName()} - This service has generated this Guid {Guid.NewGuid()} after being invoked at {DateTime.Now}.";
        }
    }
}
