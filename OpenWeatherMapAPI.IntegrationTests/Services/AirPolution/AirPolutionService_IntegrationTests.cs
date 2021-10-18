using Flurl.Http;
using OpenWeatherMapAPI.Services.AirPolution;
using OpenWeatherMapAPI.TestResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OpenWeatherMapAPI.IntegrationTests.Services.AirPolution
{
    public class AirPolutionService_IntegrationTests
    {

		private readonly IAirPolutionService _sut;
		public AirPolutionService_IntegrationTests()
		{

			_sut = new AirPolutionService(BaseConstants.APIkey);
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
