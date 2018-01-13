using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterPeople;

namespace SmartCity
{
    class Program
    {
        static void Main(string[] args)
        {
            AssemblyMaster am = new AssemblyMaster();
            am.pathToCityServices = "smartCityService.xml";

            PoliceStation cs = new PoliceStation();
            cs.ServiceName = "Полиция";
            cs.SeviceCode = 102;
            am.CreateCityCervise(cs);

            am.pathToCities = "smartCityCities.xml";
            City city = new City();
            city.CityName = "Алматы";
            city.Population = 1787964;
            city.Area = 682;
            city.Services = new List<PoliceStation> { cs };
            am.CreateCity(city);

            am.pathToRegion = "smartCityRegion.xml";
            Region region = new Region();
            region.RegionName = "Алматинская область";
            region.Population = 21241123;
            region.CapitalRegion = city;
            region.cities = null;
            am.CreateRegion(region);


        }
    }
}
