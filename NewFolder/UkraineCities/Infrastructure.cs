using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UkraineCities
{
    internal class CityData
    {
        public static City[] GetCities()
        {
            return new City[]
            {
                new City {Name = "Kyiv", neighbors = new Dictionary<string, decimal>{{"Chernihiv", 140.5m}, {"Zhytomyr", 140m}, {"Poltava", 340m}}},
                new City {Name = "Chernihiv", neighbors = new Dictionary<string, decimal>{{"Kyiv", 140}, {"Sumy", 160}}},
                new City {Name = "Zhytomyr", neighbors = new Dictionary<string, decimal>{{"Kyiv", 140}, {"Vinnytsia", 120}}},
                new City {Name = "Poltava", neighbors = new Dictionary<string, decimal>{{"Kyiv", 340.4m}, {"Kharkiv", 140}}},
                new City {Name = "Vinnytsia", neighbors = new Dictionary<string, decimal>{{"Zhytomyr", 120}, {"Khmelnytskyi", 120}}},
                new City {Name = "Sumy", neighbors = new Dictionary<string, decimal>{{"Chernihiv", 160}, {"Kharkiv", 180.6m}}},
                new City {Name = "Kharkiv", neighbors = new Dictionary<string, decimal>{{"Poltava", 140}, {"Sumy", 180}}},
                new City {Name = "Khmelnytskyi", neighbors = new Dictionary<string, decimal>{{"Vinnytsia", 120}, {"Lviv", 260}}},
                new City {Name = "Lviv", neighbors = new Dictionary<string, decimal>{{"Khmelnytskyi", 260}, {"Ternopil", 130}}},
                new City {Name = "Ternopil", neighbors = new Dictionary<string, decimal>{{"Lviv", 130}}}
            };
        }
    }
}
