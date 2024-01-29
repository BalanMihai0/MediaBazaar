using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreLibrary
{

    /// <summary>
    /// this interface is implemented by LocationsDataHandler, in DataLibrary
    /// usage: avoid circular dependency, dependency inversion principle. 
    /// manager class uses methods from here
    /// </summary>
    public interface ILocationsDataInterface
    {
        int GenerateNewLocationId();
        void AddLocationToDatabase(Location location);
        void RemoveLocationFromDatabase(int id);
        List<Location> GetLocations();
    }
}
