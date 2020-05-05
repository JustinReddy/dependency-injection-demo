using dependency_injection_demo.Controllers;
using dependency_injection_demo.Middleware.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using System.IO;

namespace dependency_injection_demo.tests
{
    /// <summary>
    /// https://www.dotnetcurry.com/aspnet-mvc/1110/testing-mvc-controller-using-nunit
    /// </summary>
    [TestFixture]
    public class HomeControllerTests
    {
        private ILogger<HomeController> _logger;
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
            _logger = Mock.Of<ILogger<HomeController>>();
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
        public void TestHomeControllerIndex()
        {
            var homecontroller = new HomeController(_logger, _config, _applicationSettings);
            var actionresult = homecontroller.Index() as ViewResult;
            Assert.IsNotNull(actionresult);
            Assert.That(actionresult.ViewName, Is.EqualTo("Index"));
        }

        [Test]
        public void TestHomeControllerInjectServiceInView()
        {
            var homecontroller = new HomeController(_logger, _config, _applicationSettings);
            var actionresult = homecontroller.InjectServiceInView() as ViewResult;
            Assert.IsNotNull(actionresult);
            Assert.That(actionresult.ViewName, Is.EqualTo("InjectServiceInView"));
        }
    }
}