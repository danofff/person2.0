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
        public List<District> Districts { get; set; }

        public City()
        {
            Districts = new List<District>();
        }             
    }
}
