using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;

namespace MasterPeople
{
    class AssemblyMaster
    {
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

            SoapFormatter formatter = new SoapFormatter();
            try
            {
                using (FileStream fs = new FileStream(pathToRegion, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, region);
                }
                return true;
            }
            catch (Exception)
            {
                return false;                                
            }        
        }

        private List<Region> GetRegion()
        {
            List<Region> regions = new List<Region>();
            SoapFormatter formatter = new SoapFormatter();
            FileInfo fi = new FileInfo(pathToRegion);
            if (fi.Exists)
            {
                using (FileStream fs=new FileStream(pathToRegion, FileMode.OpenOrCreate))
                {
                    regions = (List<Region>)formatter.Deserialize(fs);
                }              
            }
            return regions==null?new List<Region>():regions; 
        }
    }
}
