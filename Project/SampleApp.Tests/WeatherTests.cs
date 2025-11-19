using System.Net;
using Xunit;

namespace SampleApp.Tests;

public class WeatherTests(SampleAppFactory factory)
    : SampleAppTestBase(factory)
{
    [Fact]
    public async Task GetWeatherForecast_ReturnsSuccess()
    {
        var response = await Client.GetAsync("/weatherforecast");

        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
