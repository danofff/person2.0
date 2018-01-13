using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterPeople;
using person;

namespace PoliceMaster
{
    class PoliceStation
    {
        public string NamePoliceStation { get; set; }
        public int CodePoliceStation { get; set; }
        public List<PolicePeople> workers { get; set; } = new List<PolicePeople>();
        public City city { get; set; }

    }
}
