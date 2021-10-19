using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeatherMapAPI.Models.Shared
{
	public static class OpenWeatherMapAPIClientConfiguration
	{
		/// <summary>
		/// Default API URL
		/// </summary>
		public static string APIURL { get; set; } = Constants.APIUrl;
		
		/// <summary>
		/// Default API Version to use
		/// </summary>
		public static string APIVersion { get; set; } = Constants.Ver2_5;
		
		/// <summary>
		/// API key. More at: https://openweathermap.org/appid
		/// </summary>
		public static string APIKey { get; set; } = "YOUR_API_KEY";
	}
}
