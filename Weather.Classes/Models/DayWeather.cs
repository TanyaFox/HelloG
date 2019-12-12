using System;

namespace Weather.Classes.Models
{
	public class DayWeather
	{
		public DateTime Date { get; set; }
		public double Temperature { get; set; }
		public int Humidity { get; set; }
		public int LocationId { get; set; }

		public bool IsValid()
		{	
			return true;
		}
	}
}
