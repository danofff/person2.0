using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using PoliceMaster;

namespace MasterPeople
{
    public class AssemblyMaster
    {

        #region CREATE CITY
        public string pathToCity { get; set; } = "";
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
            City city = null;      
            XmlSerializer formatter = new XmlSerializer(typeof(City));

            if (String.IsNullOrEmpty(pathToCity))
            {
                Console.WriteLine("No path to city storage");
                return null;
            }
            FileInfo fi = new FileInfo(pathToCity);
            if (fi.Exists)
            {
                using (FileStream fs = new FileStream(pathToCity, FileMode.OpenOrCreate))
                {
                    city=((City)formatter.Deserialize(fs));
                }
            }
            return city;
        }
        #endregion

        #region CREATE POLICE STATION
        public string pathToPoliceStations { get; set; }
        public bool CreatePoliceStation(PoliceStation policeStation)
        {
            List<PoliceStation> policeStations = GetPoliceStations();
            policeStations.Add(policeStation);

            XmlSerializer formatter = new XmlSerializer(typeof(List<PoliceStation>));
            try
            {
                using (FileStream fs = new FileStream(pathToPoliceStations, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, policeStations);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<PoliceStation> GetPoliceStations()
        {
            List<PoliceStation> policeStations = new List<PoliceStation>();
            XmlSerializer formatter = new XmlSerializer(typeof(List<PoliceStation>));
            FileInfo fi = new FileInfo(pathToPoliceStations);
            if (fi.Exists)
            {
                using (FileStream fs = new FileStream(pathToPoliceStations, FileMode.OpenOrCreate))
                {
                    policeStations = (List<PoliceStation>)formatter.Deserialize(fs);
                }
            }
            return policeStations == null ? new List<PoliceStation>() : policeStations;
        }
        #endregion


    }
}
