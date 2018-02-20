using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterPeople;
using person;
using PoliceMaster;
using person.ModelHuman;

namespace SmartCity
{
    public class GenerateCity
    {
        //вспомогательная статическая рандомная переменная
        private static Random rnd;
        //статическая переменная для подсчета количества районов в городе
        private static int districtCountHandler;
        private int DistrictCount;
        public GenerateCity(int districtCount)
        {
            districtCountHandler = 0;
            DistrictCount = districtCount;
            rnd = new Random();
        }
           
        public City generateCity()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Начинаем генерировать город");
            City c = new City();
            for(int i = 0; i < DistrictCount; i++)
            {
                c.Districts.Add(this.generateDistrict());
            }
            return c;
        }

        private District generateDistrict()
        {
            
            District d = new District();
            districtCountHandler += 1;
            d.DistrictID = districtCountHandler;
            Console.WriteLine("Генерируем район {0}, генерируем для него жителей, немного подождите",d.DistrictID);

            //генерируем людей для нового района
            HumanGenerator hg = new HumanGenerator();                      
            for (int i = 0; i < rnd.Next(5,11); i++)
            {
                d.Citizens.Add(hg.AdultGenerator());
                if (i % 3 == 0)
                {
                    d.Citizens.Add(hg.KidGenerator());
                }
                if (i % 5 == 0)
                {
                    d.Citizens[i].inv = true;
                }
            }
            //прописываем в район полицейскую станцию
            
            signPoliceStationToDistrict(d);        
            return d;
        }

        private void signPoliceStationToDistrict(District d)
        {
            Console.WriteLine("Прописываем в район полицейскую станцию");

            //загружаем имеющийся список полицейских станций
            AssemblyMaster asMasterForPoliceStations = new AssemblyMaster();
            asMasterForPoliceStations.pathToPoliceStations = "policeStations.xml";
            List<PoliceStation> PoliceStations = new List<PoliceStation>();
            PoliceStations = asMasterForPoliceStations.GetPoliceStations();

            //если список полицейских станций пуст генерируем новую полицейскую станцию
            if (PoliceStations == null)
            {
                d.PoliceStat = GeneratePoliceStation();
                Console.WriteLine("Введите название полицейской станции {0} района", d.DistrictID);              
                d.PoliceStat.NamePoliceStation = Console.ReadLine();
                d.PoliceStat.ifItPlaceInDistrict = true;
                d.PoliceStat.CodePoliceStation = d.DistrictID;
                asMasterForPoliceStations.CreatePoliceStation(d.PoliceStat);
                return;                               
            }
            //если список полицейских станций не пуст, проверяем, прописана 
            //ли в район полицейская станция если нет, прописываем ее в район
            for (int i = 0; i < PoliceStations.Count; i++)
            {
                if (!PoliceStations[i].ifItPlaceInDistrict)
                {
                    d.PoliceStat = PoliceStations[i];
                    PoliceStations[i].ifItPlaceInDistrict = true;
                }
            }

            if (d.PoliceStat == null)
            {
                d.PoliceStat = GeneratePoliceStation();
                d.PoliceStat.ifItPlaceInDistrict = true;
                Console.WriteLine("Введите название полицейской станции {0} района", d.DistrictID);               
                d.PoliceStat.NamePoliceStation = Console.ReadLine();
                d.PoliceStat.CodePoliceStation = d.DistrictID;
                asMasterForPoliceStations.CreatePoliceStation(d.PoliceStat);
            }          
        }
        //метод генерирования полицейского участка и наполнения его людьми
        private PoliceStation GeneratePoliceStation()
        {
            PoliceStation pStation = new PoliceStation();
            PoliceGenerator pg = new PoliceGenerator();
            for (int i = 0; i < 5; i++)
            {
                pStation.workers.Add(pg.PoliceGenerate());
            }      
            return pStation;
        }
    }
}
