using OpenWeatherMapAPI.APIClient;
using OpenWeatherMapAPI.Models.Shared;
using OpenWeatherMapAPI.TestResources;
using Xunit;

namespace OpenWeatherMapAPI.IntegrationTests.APIClient
{
	public class APIClient_IntegrationTests
	{
		private readonly OpenWeatherMapAPIClient _sut;
		public APIClient_IntegrationTests()
		{
			_sut = new OpenWeatherMapAPIClient();
			OpenWeatherMapAPIClientConfiguration.APIKey = BaseConstants.APIkey;
		}

		[Fact]
		public async void CanCallAny_CurrentWeatherDataService_Method()
		{
			// Arrange:
			var req = Requests.ByGeographicCoordinatesRequest_Valid;

			// Act:
			var res = await _sut.CurrentWeatherData.ByGeographicCoordinatesAsync(req);

			// Assert:
			Assert.NotNull(res);
		}

		[Fact]
		public async void CanCallAny_AirPollutionService_Method()
		{
			// Arrange:
			var req = Requests.ByGeographicCoordinatesRequest_Valid;

			// Act:
			var res = await _sut.AirPollution.ByGeographicCoordinatesAsync(req);

			// Assert:
			Assert.NotNull(res);
		}
	}
}
