using OpenWeatherMapAPI.Models.CurrentWeatherData;
using System.Threading.Tasks;

namespace OpenWeatherMapAPI.Services.CurrentWeatherData
{
	public interface ICurrentWeatherDataService
	{
		Task<CurrentWeatherDataResponse> ByGeographicCoordinatesAsync(ByGeographicCoordinatesRequest request);
	}
}