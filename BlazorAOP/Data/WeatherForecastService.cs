using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorAOP.Data
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private String[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public void ClearSummaries()
        {
            Summaries = Array.Empty<String>();
        }
    }
}