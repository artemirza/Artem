using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UkraineCities
{
    internal class City
    {
        public string Name;
        public Dictionary<string, decimal> neighbors;

        static public void PrintCities()
        {
            foreach (var city in CityData.GetCities())
            {
                Console.WriteLine(city.Name);
            }
        }

        static public City FindCity(string cityName)
        {
            foreach(var city in CityData.GetCities())
            {
                if (city.Name == cityName)
                    return city;
            }
            return null;
        }

        static public bool ContainsCity(string cityName)
        {
            foreach (var city in CityData.GetCities())
            {
                if (city.Name == cityName)
                    return true;
            }
            return false;
        }
    }
}
