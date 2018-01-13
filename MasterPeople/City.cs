using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterPeople
{
    [Serializable]
    public class City
    {
        public string CityName { get; set; }
        public int Population { get; set; }
        public int Area { get; set; }
        public List<CityService> Services { get; set; }
        public string Coordinates { get; set; }
    }
}
