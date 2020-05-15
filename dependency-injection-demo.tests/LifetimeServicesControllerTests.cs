using dependency_injection_demo.Controllers;
using dependency_injection_demo.Middleware.Config;
using dependency_injection_demo.Services.LifetimeServices;
using dependency_injection_demo.Services.SampleService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using System.IO;

namespace dependency_injection_demo.tests
{
    [TestFixture]
    public class LifetimeServicesControllerTests
    {
        private ILogger<LifetimeServicesController> _logger;
        private IConfiguration _config;
        private IOptions<ApplicationSettings> _applicationSettings;

        [SetUp]
        public void Setup()
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true)
            .Build();

            _config = configuration;
            _logger = Mock.Of<ILogger<LifetimeServicesController>>();
            _applicationSettings = Options.Create(configuration.Get<ApplicationSettings>());
        }

        [Test]
        public void TestConfigLoad()
        {
            Assert.IsNotNull(_config);
            Assert.IsNotNull(_applicationSettings.Value);
            Assert.AreEqual(_applicationSettings.Value.EnvironmentName, "TEST");
        }

        [Test]
        public void TestLifetimeServicesControllerIndex()
        {
            var sampleTransientService = new Mock<ISampleTransientService>();
            var sampleSingletonService = new Mock<ISampleSingletonService>();
            var sampleScopedService = new Mock<ISampleScopedService>();
            var lifetimeServicesController = new LifetimeServicesController(_logger, _config, _applicationSettings, sampleTransientService.Object, sampleSingletonService.Object, sampleScopedService.Object);
            var actionresult = lifetimeServicesController.Index() as ViewResult;
            Assert.IsNotNull(actionresult);
            Assert.That(actionresult.ViewName, Is.EqualTo("Index"));
        }

        [Test]
        public void TestLifetimeServicesControllerGetSampleService()
        {
            var sampleTransientService = new Mock<ISampleTransientService>();
            var sampleSingletonService = new Mock<ISampleSingletonService>();
            var sampleScopedService = new Mock<ISampleScopedService>(); 
            var sampleActivatorService = new Mock<ISampleService>();
            var lifetimeServicesController = new LifetimeServicesController(_logger, _config, _applicationSettings, sampleTransientService.Object, sampleSingletonService.Object, sampleScopedService.Object);
            var actionresult = lifetimeServicesController.GetSampleService(sampleActivatorService.Object) as ViewResult;
            Assert.IsNotNull(actionresult);
            Assert.That(actionresult.ViewName, Is.EqualTo("GetSampleService"));
        }
    }
}
