using EmployeeManagement.DataAccess;
using EmployeeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Core.Services
{
    public class LocationService
    {
        List<LocationModel> locationList = LocationDataAccess.GetAll();
        public bool Add(LocationModel location)
        {
            if (locationList == null)
            {
                locationList = new List<LocationModel>();
            }
            locationList.Add(location);
            return LocationDataAccess.Set(locationList); ;
        }

        public List<LocationModel> ViewAll()
        {
            return LocationDataAccess.GetAll();
        }
    }
}
