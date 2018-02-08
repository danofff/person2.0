using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using person.ModelHuman;

namespace MasterPeople
{
    [Serializable]
    public class City
    {
        public string CityName { get; set; }
        public List<CityService> Services { get; set; }
        public List<Person> citizens { get; set; }
        public string Coordinates { get; set; }

        public City()
        {
            citizens = new List<Person>();
        }
    }
}
