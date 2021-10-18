using Flurl.Http;
using Newtonsoft.Json;
using OpenWeatherMapAPI.APIClient;
using OpenWeatherMapAPI.TestResources;
using System;
using System.Threading.Tasks;

namespace OpenWeatherMapAPI.SystemTests
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var sut = new OpenWeatherMapAPIClient(BaseConstants.APIkey);
			CurrentWeatherDataService_ByGeographicCoordinatesAsync_CanGetResult(sut).Wait();
			CurrentWeatherDataService_ByGeographicCoordinatesAsync_ThrowsOnWrongInput(sut).Wait();
		}

		#region CurrentWeatherDataService
		private static async Task CurrentWeatherDataService_ByGeographicCoordinatesAsync_CanGetResult(OpenWeatherMapAPIClient client)
		{
			Console.WriteLine($"Running system test: {nameof(CurrentWeatherDataService_ByGeographicCoordinatesAsync_CanGetResult)}");
			var sut = client.CurrentWeatherData;
			var result = await sut.ByGeographicCoordinatesAsync(CurrentWeatherDataSamples.ByGeographicCoordinatesRequest_Valid);
			Console.WriteLine(JsonConvert.SerializeObject(result));
			Console.WriteLine("SUCCESS");
		}

		private static async Task CurrentWeatherDataService_ByGeographicCoordinatesAsync_ThrowsOnWrongInput(OpenWeatherMapAPIClient client)
		{
			Console.WriteLine($"Running system test: {nameof(CurrentWeatherDataService_ByGeographicCoordinatesAsync_ThrowsOnWrongInput)}");
			var sut = client.CurrentWeatherData;
			try
			{
				var result = await sut.ByGeographicCoordinatesAsync(CurrentWeatherDataSamples.ByGeographicCoordinatesRequest_Invalid);
			}
			catch (FlurlHttpException ex)
			{
				if (ex.StatusCode == 400)
				{
					Console.WriteLine("SUCCESS");
				}
				else
				{
					Console.WriteLine("RESPONSE IS OTHER THAN BAD REQUEST - UNEXPECTED EXCEPTION");
					Console.WriteLine(JsonConvert.SerializeObject(ex));
				};
			}
		}
		#endregion
	}
}
