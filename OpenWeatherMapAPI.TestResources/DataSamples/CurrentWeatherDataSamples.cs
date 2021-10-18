using OpenWeatherMapAPI.Models.CurrentWeatherData;

namespace OpenWeatherMapAPI.TestResources
{
	public static class CurrentWeatherDataSamples
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
