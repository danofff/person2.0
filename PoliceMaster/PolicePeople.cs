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
    public class PolicePeople:Adult
    {
        public PolicePeople()
        {
            this.IsWorking = true;
        }
        public string Rang { get; set; }
        public double Salary { get; set; }
    }
}
