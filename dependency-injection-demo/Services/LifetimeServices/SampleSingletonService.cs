using System;
using System.Reflection;

namespace dependency_injection_demo.Services.LifetimeServices
{
    public class SampleSingletonService : ISampleSingletonService
    {
        private readonly Guid guid;
        private readonly DateTime dateTime;

        public SampleSingletonService()
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
