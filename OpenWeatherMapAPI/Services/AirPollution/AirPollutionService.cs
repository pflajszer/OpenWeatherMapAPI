using OpenWeatherMapAPI.Models.AirPollution;
using OpenWeatherMapAPI.Models.Shared;
using OpenWeatherMapAPI.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMapAPI.Services.AirPollution
{
	public class AirPollutionService : APIGateway, IAirPollutionService
	{
		public AirPollutionService()
			: base(Constants.Endpoint_AirPollution)
		{
		}

		public async Task<AirPollutionResponse> ByGeographicCoordinatesAsync(ByGeographicCoordinatesRequest request)
		{
			var res = await ExecuteGetAsync<AirPollutionResponse>(new
			{
				lat = request.Latitude,
				lon = request.Longitude,
				appid = OpenWeatherMapAPIClientConfiguration.APIKey
			});
			return res;
		}
	}
}
