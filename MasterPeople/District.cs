using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PoliceMaster;
using person.ModelHuman;

namespace MasterPeople
{
    public class District
    {
        public int DistrictID { get; set; }
        public string Name { get; set; }
        private bool HasPoliceStation { get; set; }
        public District()
        {
            HasPoliceStation = false;
        }
        public PoliceStation PoliceStat { get; set; } = null;
        public List<Person> Citizens { get; set; } = new List<Person>();

    }
}
