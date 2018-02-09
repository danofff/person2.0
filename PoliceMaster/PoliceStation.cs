using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using person;

namespace PoliceMaster
{
    [Serializable]
    public class PoliceStation
    {
        public bool ifItPlaceInDistrict { get; set; } = false;
        public string NamePoliceStation { get; set; }
        public int CodePoliceStation { get; set; }
        public List<PolicePeople> workers { get; set; } = new List<PolicePeople>();
        public void printInfoAboutPoliceStation()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"NAME POLICE STATION: {NamePoliceStation}, NUMBER: {CodePoliceStation}, COUNT OF POLICEMAN: {workers.Count}");

            for (int i = 0; i < workers.Count; i++)
            {
                workers[i].PrintShortInfo();
            }
        }
        
    }
}
