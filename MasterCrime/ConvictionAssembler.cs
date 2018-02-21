using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using person.ModelHuman;
using PoliceMaster;
using MasterPeople;
using System.IO;
using System.Xml.Serialization;

namespace MasterCrime
{
    public class ConvictionAssembler
    {
        public string pathToConvictions { get; set; } = "convictions.xml";

        private City city { get; set; }

        public ConvictionAssembler(City c)
        {
            city = c;           
        }

        public Conviction generateConviction()
        {
            Console.ForegroundColor = ConsoleColor.Red;        
            Conviction conviction = new Conviction();
            Random rnd = new Random();
            conviction.ConvictionType = (convicType)rnd.Next(0, 6);
            conviction.ConvictionCommitDate = DateTime.Now.AddHours(-rnd.Next(0, 24));
            Console.WriteLine("Где-то, кто-то совершил преступление {0}!!!",conviction.ConvictionType);
            int distNumber = rnd.Next(0, city.Districts.Count);
            conviction.DistrictOfConviction = distNumber;

            //определяем лицо совершившее преступление
            int i = 0;
            while (true)
            {
                i = rnd.Next(0, city.Districts[distNumber].Citizens.Count);
               //Console.WriteLine($"район {}  житель {}");
                if (city.Districts[distNumber].Citizens[i].GetType().ToString() == "person.ModelHuman.Adult")
                {
                    conviction.personCommitConviction = city.Districts[distNumber].Citizens[i].Name;
                    city.Districts[distNumber].Citizens[i].Convictions.Add(conviction);
                    break;
                }
            }
            CreateConviction(conviction);                   
            return conviction;
        }

        //сохраняем преступление
        public bool CreateConviction(Conviction conv)
        {
            List<Conviction> Convictions = GetConvictions();
            Convictions.Add(conv);

            XmlSerializer formatter = new XmlSerializer(typeof(List<Conviction>));
            try
            {
                using (FileStream fs = new FileStream(pathToConvictions, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, Convictions);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public List<Conviction> GetConvictions()
        {
            List<Conviction> Convictions = new List<Conviction>();
            XmlSerializer formatter = new XmlSerializer(typeof(List<Conviction>));
            FileInfo fi = new FileInfo(pathToConvictions);

            if (fi.Exists)
            {
                using (FileStream fs = new FileStream(pathToConvictions, FileMode.OpenOrCreate))
                {
                    Convictions = (List<Conviction>)formatter.Deserialize(fs);
                }
            }
            return Convictions == null ? new List<Conviction>() : Convictions;
        }




        //расследование преступления
        public void Investigate(Conviction conviction)
        {
            Console.WriteLine("Преступление будет расследовать: ");                    
            PolicePeople policeman=new PolicePeople();

            policeman = GetPolicePeople(conviction.DistrictOfConviction);
            if (policeman != null)
            {
                policeman.PrintShortInfo();
                conviction.Investiagator = policeman.Name;
            }          
        }
        private PolicePeople GetPolicePeople(int district)
        {
            for (int i = 0; i < city.Districts[district].PoliceStat.workers.Count; i++)
            {
                if (city.Districts[district].PoliceStat.workers[i].freeStatus)
                {
                    city.Districts[district].PoliceStat.workers[i].freeStatus = false;
                    return city.Districts[district].PoliceStat.workers[i];                                     
                }               
            }
            return null;
        }

    }
}
