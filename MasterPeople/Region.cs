using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterPeople
{
    [Serializable]
    public class Region
    {
        public string RegionName { get; set; }
        public int Population { get; set; }
        public City CapitalRegion { get; set; }
        public List<City> cities { get; set; }
    }
}
