using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterPeople
{
    [Serializable]
    public class CityService
    {
        public int districtNumber { get; set; }
        public int SeviceCode { get; set; }
        public string ServiceName { get; set; }
    }
}
