using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreLibrary
{
    public class LocationsManager
    {
        private readonly ILocationsDataInterface _locationDataStorage;

        public LocationsManager(ILocationsDataInterface dataInterface)
        {
            _locationDataStorage = dataInterface;
        }

        public List<Location> GetLocations()
        {
            return _locationDataStorage.GetLocations();
        }

        public void AddLocations(int floor, int roomNumber)
            //maybe they expand idk
        {
            _locationDataStorage.AddLocationToDatabase(new Location(_locationDataStorage.GenerateNewLocationId(), floor, roomNumber));
        }

        public void RemoveLocation(int id)
            //maybe they got evicted idk
        {
            _locationDataStorage.RemoveLocationFromDatabase(id);
        }
    }
}
