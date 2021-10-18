using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeatherMapAPI.Models.Shared
{
	public  class ByGeographicCoordinatesRequest
	{
		public double Longitude { get; set; }
		public double Latitude {  get; set; }
	}
}
