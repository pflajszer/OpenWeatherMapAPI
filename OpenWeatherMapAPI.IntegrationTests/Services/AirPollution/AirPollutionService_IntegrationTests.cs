using Flurl.Http;
using OpenWeatherMapAPI.Services.AirPollution;
using OpenWeatherMapAPI.TestResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OpenWeatherMapAPI.IntegrationTests.Services.AirPollution
{
    public class AirPollutionService_IntegrationTests
    {

		private readonly IAirPollutionService _sut;
		public AirPollutionService_IntegrationTests()
		{

			_sut = new AirPollutionService(BaseConstants.APIkey);
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
