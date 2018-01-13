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
        #region CREATE REGION
        /// <summary>
        /// Путь к файлу региона
        /// </summary>
        public string pathToRegion { get; set; }
        /// <summary>
        /// Создание региона
        /// </summary>
        /// <param name="region"></param>
        /// <returns>bool</returns>
        public bool CreateRegion(Region region)
        {
            List<Region> regions = GetRegion();
            regions.Add(region);

            XmlSerializer formatter = new XmlSerializer(typeof(List<Region>));
            try
            {
                using (FileStream fs = new FileStream(pathToRegion, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, regions);
                }
                return true;
            }
            catch (Exception)
            {
                return false;                                
            }        
        }
        /// <summary>
        /// Проверка на существование файла региона
        /// </summary>
        /// <returns></returns>
        public List<Region> GetRegion()
        {
            List<Region> regions = new List<Region>();
            XmlSerializer formatter = new XmlSerializer(typeof(List<Region>));
            FileInfo fi = new FileInfo(pathToRegion);
            if (fi.Exists)
            {
                using (FileStream fs=new FileStream(pathToRegion, FileMode.OpenOrCreate))
                {
                    regions=(List<Region>)formatter.Deserialize(fs);
                }              
            }
            return regions==null?new List<Region>():regions; 
        }
        #endregion

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
        public bool CreateCityCervise(PoliceStation cityService)
        {
            List<PoliceStation> cityServices = GetCitySrvices();
            cityServices.Add(cityService);

            XmlSerializer formatter = new XmlSerializer(typeof(List<PoliceStation>));
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
        public List<PoliceStation> GetCitySrvices()
        {
            List<PoliceStation> cityServices = new List<PoliceStation>();
            XmlSerializer formatter = new XmlSerializer(typeof(List<PoliceStation>));
            FileInfo fi = new FileInfo(pathToCityServices);
            if (fi.Exists)
            {
                using (FileStream fs = new FileStream(pathToCityServices, FileMode.OpenOrCreate))
                {                    
                    cityServices=(List<PoliceStation>)formatter.Deserialize(fs);
                }
            }
            return cityServices == null ? new List<PoliceStation>() : cityServices;
        }
        #endregion
    }
}
