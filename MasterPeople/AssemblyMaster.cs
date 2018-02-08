using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace MasterPeople
{
    public class AssemblyMaster
    {
        
        #region CREATE CITY
        public string pathToCities { get; set; }
        public bool CreateCity(City city)
        {
            List<City> cities = GetCities();

            cities.Add(city);

            XmlSerializer formatter = new XmlSerializer(typeof(List<City>));
            try
            {
                using (FileStream fs = new FileStream(pathToCities, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, cities);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<City> GetCities()
        {
            List<City> cities = new List<City>();      
            XmlSerializer formatter = new XmlSerializer(typeof(List<City>));

            FileInfo fi = new FileInfo(pathToCities);
            if (fi.Exists)
            {
                using (FileStream fs = new FileStream(pathToCities, FileMode.OpenOrCreate))
                {
                    cities=(List<City>)formatter.Deserialize(fs);
                }
            }
            return cities == null ? new List<City>() : cities;
        }
        #endregion

        #region CREATE CITY SEVICE
        public string pathToCityServices { get; set; }
        public bool CreateCityCervise(CityService cityService)
        {
            List<CityService> cityServices = GetCitySrvices();
            cityServices.Add(cityService);

            XmlSerializer formatter = new XmlSerializer(typeof(List<CityService>));
            try
            {
                using (FileStream fs = new FileStream(pathToCityServices, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, cityServices);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<CityService> GetCitySrvices()
        {
            List<CityService> cityServices = new List<CityService>();
            XmlSerializer formatter = new XmlSerializer(typeof(List<CityService>));
            FileInfo fi = new FileInfo(pathToCityServices);
            if (fi.Exists)
            {
                using (FileStream fs = new FileStream(pathToCityServices, FileMode.OpenOrCreate))
                {                    
                    cityServices=(List<CityService>)formatter.Deserialize(fs);
                }
            }
            return cityServices == null ? new List<CityService>() : cityServices;
        }
        #endregion

        #region CREATE PEOPLE

        #endregion  
    }
}
