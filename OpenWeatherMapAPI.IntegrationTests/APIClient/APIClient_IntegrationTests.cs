using OpenWeatherMapAPI.APIClient;
using OpenWeatherMapAPI.TestResources;
using Xunit;

namespace OpenWeatherMapAPI.IntegrationTests.APIClient
{
	public class APIClient_IntegrationTests
	{
		private readonly OpenWeatherMapAPIClient _sut;
		public APIClient_IntegrationTests()
		{
			_sut = new OpenWeatherMapAPIClient(BaseConstants.APIkey);
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
	}
}
