using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterPeople;
using person;
using System.Xml.Serialization;
using System.IO;
using person;

namespace PoliceMaster
{
    public class MasterPolice
    {
        private AssemblyMaster am = new AssemblyMaster();
        

        #region CREATE Police Station
        public string pathToStation { get; set; }
        public bool CreateStation(PoliceStation station,List<PoliceStation> stations=null)
        {
            List<PoliceStation> policeStations = null;
            if (stations != null)
                policeStations = stations;
            else
            {
                policeStations = GetStations();
                policeStations.Add(station);
            }
            XmlSerializer formatter = new XmlSerializer(typeof(List<PoliceStation>));
            try
            {
                using (FileStream fs = new FileStream(pathToStation, FileMode.OpenOrCreate))
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
        public List<PoliceStation> GetStations()
        {
            List<PoliceStation> policeStations = new List<PoliceStation>();
            XmlSerializer formatter = new XmlSerializer(typeof(List<PoliceStation>));
            FileInfo fi = new FileInfo(pathToStation);
            if (fi.Exists)
            {
                using (FileStream fs = new FileStream(pathToStation, FileMode.OpenOrCreate))
                {
                    policeStations = (List<PoliceStation>)formatter.Deserialize(fs);
                }
            }
            return policeStations == null ? new List<PoliceStation>() : policeStations;
        }
        #endregion

        public void AddPolicePeopleToStation(int codePs, PoliceStation station)
        {
            PolicePeople people=null;
            List<PoliceStation> policeStations = GetStations();
            PoliceStation st = policeStations.FirstOrDefault(f => f.CodePoliceStation == codePs);
            policeStations.Remove(station);
            station.workers.Add(people);
            CreateStation(null, policeStations);

        }

        #region  CREATE Police People;
        #endregion

    }
}