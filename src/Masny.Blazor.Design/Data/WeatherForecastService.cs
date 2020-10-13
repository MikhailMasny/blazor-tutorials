using System;
using System.Linq;
using System.Threading.Tasks;

namespace Masny.Blazor.Design.Data
{
    public class WeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 1000).Select(index =>
            {
                var tempC = rng.Next(-20, 55);
                return new WeatherForecast
                {
                    Date = startDate.AddDays(index),
                    TemperatureC = tempC,
                    TemperatureF = 32 + (int)(tempC / 0.5556),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                };
            }).ToArray());
        }
    }
}
