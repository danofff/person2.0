using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MasterPeople;
using PoliceMaster;
using person.ModelHuman;
using person;
using static System.Console;


namespace SmartCity
{
    class Program
    {
        static void Main(string[] args)
        {
                                                    
            AssemblyMaster am = new AssemblyMaster();
            am.pathToCity = "city.xml";
            City city = am.GetCity();
            if (city == null)
            {
                GenerateCity GenCity = new GenerateCity(4);
                city = GenCity.generateCity();
            }

            am.CreateCity(city);
            city.Districts[0].PoliceStat.workers[0].PrintShortInfo();



            ForegroundColor = ConsoleColor.Red;
        }
    }
}
