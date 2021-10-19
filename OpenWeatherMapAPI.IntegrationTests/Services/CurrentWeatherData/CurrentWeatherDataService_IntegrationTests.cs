using Flurl.Http;
using OpenWeatherMapAPI.Models.Shared;
using OpenWeatherMapAPI.Services.CurrentWeatherData;
using OpenWeatherMapAPI.TestResources;
using Xunit;

namespace OpenWeatherMapAPI.IntegrationTests.Services.CurrentWeatherData
{
	public class CurrentWeatherDataService_IntegrationTests
	{

		private readonly CurrentWeatherDataService _sut;
		public CurrentWeatherDataService_IntegrationTests()
		{
			_sut = new CurrentWeatherDataService();
			OpenWeatherMapAPIClientConfiguration.APIKey = BaseConstants.APIkey;
		}

		[Fact]
		public async void ByGeographicCoordinatesAsync_CanGetResult()
		{
			// Arrange:
			var req = Requests.ByGeographicCoordinatesRequest_Valid;

			// Act:
			var res = await _sut.ByGeographicCoordinatesAsync(req);

			// Assert:
			Assert.NotNull(res);
		}

		[Fact]
		public async void ByGeographicCoordinatesAsync_ThrowsOnWrongInput()
		{
			// Arrange:
			var req = Requests.ByGeographicCoordinatesRequest_Invalid;

			// Act/Assert:
			await Assert.ThrowsAnyAsync<FlurlHttpException>(() => _sut.ByGeographicCoordinatesAsync(req));
		}

	}
}
