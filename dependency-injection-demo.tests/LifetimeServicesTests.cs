using dependency_injection_demo.Services.LifetimeServices;
using dependency_injection_demo.Services.SampleService;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace dependency_injection_demo.tests
{
    [TestFixture]
    public class LifetimeServicesTests
    {
        private ServiceProvider serviceProvider { get; set; }

        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();
            services.AddTransient<ISampleTransientService, SampleTransientService>();
            services.AddSingleton<ISampleSingletonService, SampleSingletonService>();
            services.AddScoped<ISampleScopedService, SampleScopedService>();
            serviceProvider = services.BuildServiceProvider();
        }

        [Test]
        public void TestSampleTransientServiceGetServiceInfo()
        {
            var sampleTransientService1 = (ISampleTransientService)serviceProvider.GetService(typeof(ISampleTransientService));
            var sampleTransientService2 = (ISampleTransientService)serviceProvider.GetService(typeof(ISampleTransientService));
            var sampleTransientService3 = (ISampleTransientService)serviceProvider.GetService(typeof(ISampleTransientService));
            var result1 = sampleTransientService1.GetServiceInformation();
            var result2 = sampleTransientService2.GetServiceInformation();
            var result3 = sampleTransientService2.GetServiceInformation();
            Assert.AreNotEqual(result1, result2);
            Assert.AreNotEqual(result1, result3);
        }

        [Test]
        public void TestSampleSingletonServiceGetServiceInfo()
        {
            var sampleSingletonService1 = (ISampleSingletonService)serviceProvider.GetService(typeof(ISampleSingletonService));
            var sampleSingletonService2 = (ISampleSingletonService)serviceProvider.GetService(typeof(ISampleSingletonService));
            var sampleSingletonService3 = (ISampleSingletonService)serviceProvider.GetService(typeof(ISampleSingletonService));
            var result1 = sampleSingletonService1.GetServiceInformation();
            var result2 = sampleSingletonService2.GetServiceInformation();
            var result3 = sampleSingletonService3.GetServiceInformation();
            Assert.AreEqual(result1, result2);
            Assert.AreEqual(result1, result3);
        }

        [Test]
        public void TestSampleScopedServiceGetServiceInfo()
        {
            var sampleScopedService = (ISampleScopedService)serviceProvider.GetService(typeof(ISampleScopedService));
            var result1 = sampleScopedService.GetServiceInformation();
            var result2 = sampleScopedService.GetServiceInformation();
            var result3 = sampleScopedService.GetServiceInformation();
            Assert.AreEqual(result1, result2);
            Assert.AreEqual(result1, result3);
        }
    }
}
