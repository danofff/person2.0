using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterPeople;
using person;
using person.ModelHuman;

namespace PoliceMaster
{
    public enum rang { officer, detective, sergeant, lieutenant, Captain };
    public class PolicePeople:Adult
    {
        public PolicePeople()
        {
           IsWorking = true;
           readyForJob = true;
        }
        public rang Rang { get; set; }
        public double Salary { get; set; }
        public bool readyForJob { get; set; }
    }
}
