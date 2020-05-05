using dependency_injection_demo.Services.SampleService;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace dependency_injection_demo.tests
{
    /// <summary>
    /// https://softchris.github.io/pages/dotnet-moq.html#add-unit-tests
    /// </summary>
    [TestFixture]
    public class SampleServiceTests
    {
        [Test]
        public void TestSampleServiceGetServiceInfo()
        {
            var sampleservice = new Mock<ISampleService>();
            sampleservice.Setup(c => c.GetServiceInformation()).Returns("This is a mocked response");
            var result = sampleservice.Object.GetServiceInformation();
            Assert.That(result.Contains("This is a mocked response"));
        }
    }
}
