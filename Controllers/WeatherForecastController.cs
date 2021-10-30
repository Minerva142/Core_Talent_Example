using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using first_core_app.Services;

namespace first_core_app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Soğuk", "Dondurucu", "Sıcak", "Ilık", "Terletiyor", "Çok sıcak", "Nemli"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private ITradesoftService _tradesoftService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ITradesoftService tradesoftService)
        {
            _logger = logger;
            _tradesoftService = tradesoftService;

        }

        [HttpGet]
        public IActionResult Get(string username, string password)
        {

            var result = _tradesoftService.Login(username, password);

            if (result == "Hata")
            {
                return StatusCode(500, "hatalı kullanıcı adı şifre");
            }

            var rng = new Random();
            return Ok(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray());
        }
    }
}
