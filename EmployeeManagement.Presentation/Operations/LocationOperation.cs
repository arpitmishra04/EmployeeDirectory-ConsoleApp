using EmployeeManagement.Core.Services;
using EmployeeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Presentation.Operations
{
    internal class LocationOperation
    {
        private static readonly Random random = new Random();
        public static int Add(string locationName)
        {
          
            int locationId = GenerateId();
            LocationModel location = new LocationModel
            {
                LocationId = locationId,
                LocationName = locationName,
            };
            LocationService locationService = new LocationService();
            locationService.Add(location);
            return locationId;
        }

        private static int GenerateId()
        {
            LocationService locationService = new LocationService();
            List<LocationModel> locationList =locationService.ViewAll();
        long timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            int id = 0;

            if (locationList == null)
            {
                id = random.Next(1, 1000);
            }

            else
            {
                id = locationList[locationList.Count - 1].LocationId + random.Next(1, 1000);
            }

            return id;
        }
    }
}
