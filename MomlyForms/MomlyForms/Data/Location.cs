using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;

namespace MomlyForms.Data
{
    public class Location
    {
        public static async Task<double[]> GetLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            var positionData = await locator.GetPositionAsync();

            double latitude = positionData.Latitude;
            double longtitude = positionData.Longitude;

            double[] arr = { latitude, longtitude };

            return arr;
        }

        public static async Task<double[]> GetLastKnownLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            var positionData = await locator.GetLastKnownLocationAsync();

            double latitude = positionData.Latitude;
            double longtitude = positionData.Longitude;

            double[] arr = { latitude, longtitude };

            return arr;
        }
    }
}
