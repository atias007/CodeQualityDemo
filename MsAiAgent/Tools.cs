using System.ComponentModel;

namespace MsAiAgent;

record WeatherSatus(string Title, int Degree);

internal static class Tools
{
    [Description("Get a weather for a given location.")]
    public static WeatherSatus GetWeather(
        [Description("the location to get the weather for.")] string location)
    {
        return new WeatherSatus("cloudy", 15);
    }
}