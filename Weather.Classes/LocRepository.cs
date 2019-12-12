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
    public class LocRepository
    {
        List<Location> _locations;

        public event Action<Location> LocationAdded;

        public IEnumerable<Location> Locations
        {
            get
            {
                return _locations;
            }
        }

        public LocRepository()
        {
            LoadData("Data/locations.json");
        }

        public void AddItem(Location item)
        {
            if (!item.IsValid())
                throw new ArgumentException();
            _locations.Add(item);
            LocationAdded?.Invoke(item);
        }

        public Location Find(Predicate<Location> predicate)
        {
            return _locations.Find(predicate);
        }

        public void RemoveItem(Location item)
        {
            _locations.Remove(item);
        }

        public void LoadData(string fileName)
        {
            using (var sr = new StreamReader(fileName))
            {
                using (var jsonReader = new JsonTextReader(sr))
                {
                    var serializer = new JsonSerializer();
                    _locations = serializer.Deserialize<List<Location>>(jsonReader);
                }
            }
        }

    }
}
