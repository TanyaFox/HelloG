﻿
namespace Weather.Classes.Models {
	public class Location
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public bool IsValid()
		{
			return !string.IsNullOrWhiteSpace(Name);
		}
	}
}
