using OpenWeatherMapAPI.Models.CurrentWeatherData;
using OpenWeatherMapAPI.Models.Shared;

namespace OpenWeatherMapAPI.TestResources
{
	public static class Requests
	{
		public static ByGeographicCoordinatesRequest ByGeographicCoordinatesRequest_Valid { get; } = new ByGeographicCoordinatesRequest()
		{
			Latitude = 53.7998,
			Longitude = 1.5584
		};

		public static ByGeographicCoordinatesRequest ByGeographicCoordinatesRequest_Invalid { get; } = new ByGeographicCoordinatesRequest()
		{
			Latitude = 243243,
			Longitude = 23432
		};
	}
}
