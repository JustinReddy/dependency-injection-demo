﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dependency_injection_demo.Middleware.Config;
using dependency_injection_demo.Models;
using dependency_injection_demo.Services.LifetimeServices;
using dependency_injection_demo.Services.SampleService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace dependency_injection_demo.Controllers
{

    public class LifetimeServicesController : Controller
    {
        private readonly ILogger<LifetimeServicesController> _logger;
        private readonly IConfiguration _config;
        private readonly ApplicationSettings _applicationSettings;
        private readonly ISampleTransientService _sampleTransientService;
        private readonly ISampleSingletonService _sampleSingletonService;
        private readonly ISampleScopedService _sampleScopedService;

        public LifetimeServicesController(ILogger<LifetimeServicesController> logger, IConfiguration Configuration, IOptions<ApplicationSettings> applicationSettings, ISampleTransientService sampleTransientService, ISampleSingletonService sampleSingletonService, ISampleScopedService sampleScopedService)
        {
            _logger = logger;
            _config = Configuration;
            _applicationSettings = applicationSettings.Value;
            _sampleTransientService = sampleTransientService;
            _sampleSingletonService = sampleSingletonService;
            _sampleScopedService = sampleScopedService;
        }

        public IActionResult Index()
        {
            var model = new LifetimeTestViewModel();
            model.TransientDescription = _sampleTransientService.GetServiceInformation();
            model.SingletonDescription = _sampleSingletonService.GetServiceInformation();
            model.ScopedDescription = _sampleScopedService.GetServiceInformation();
            return View("Index", model);
        }

        public IActionResult GetSampleService([FromServices] ISampleService sampleservice)
        {
            var model = new LifetimeTestViewModel();
            model.TransientDescription = _sampleTransientService.GetServiceInformation();
            return View("GetSampleService", model);
        }
    }
}