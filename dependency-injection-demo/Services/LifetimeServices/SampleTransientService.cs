using System;
using System.Reflection;

namespace dependency_injection_demo.Services.LifetimeServices
{
    public class SampleTransientService : ISampleTransientService
    {
        private readonly Guid guid;
        private readonly DateTime dateTime;

        public SampleTransientService()
        {
            guid = Guid.NewGuid();
            dateTime = DateTime.Now;
        }
        public string GetServiceInformation()
        {
            return $"{Assembly.GetExecutingAssembly().GetName()} - This service has generated this Guid {guid} after being invoked at {dateTime}.";
        }
    }
}
