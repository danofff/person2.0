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
        public string pathToCity { get; set; }
        public bool CreateCity(City city)
        {
                      
            XmlSerializer formatter = new XmlSerializer(typeof(City));
            try
            {
                using (FileStream fs = new FileStream(pathToCity, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, city);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public City GetCity()
        {
            City city = new City();      
            XmlSerializer formatter = new XmlSerializer(typeof(City));

            FileInfo fi = new FileInfo(pathToCity);
            if (fi.Exists)
            {
                using (FileStream fs = new FileStream(pathToCity, FileMode.OpenOrCreate))
                {
                    city=((City)formatter.Deserialize(fs));
                }
            }
            return city == null ? new City() : city;
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


    }
}
