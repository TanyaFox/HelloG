using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Classes.Models;

namespace Weather.Classes
{
    public class WeathRepository
    {
        List<DayWeather> _weather;

        public event Action<DayWeather> WeatherAdded;

        public IEnumerable<DayWeather> Weathers
        {
            get
            {
                return _weather;
            }
        }

        public WeathRepository()
        {
            LoadData("Data/weather.json");
        }

        public void AddItem(DayWeather item)
        {
            if (!item.IsValid())
                throw new ArgumentException();
            _weather.Add(item);
            WeatherAdded?.Invoke(item);
        }

        public DayWeather Find(Predicate<DayWeather> predicate)
        {
            return _weather.Find(predicate);
        }

        public void RemoveItem(DayWeather item)
        {
            _weather.Remove(item);
        }

        public void LoadData(string fileName)
        {
            using (var sr = new StreamReader(fileName))
            {
                using (var jsonReader = new JsonTextReader(sr))
                {
                    var serializer = new JsonSerializer();
                    _weather = serializer.Deserialize<List<DayWeather>>(jsonReader);
                }
            }
        }

        public IEnumerable<DayWeather> GetWeatherForLocation(int locationId)
        {
            return Weathers.Where(dw => dw.LocationId == locationId);
        }
    }
}
