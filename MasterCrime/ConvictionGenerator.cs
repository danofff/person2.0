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
        public string pathToConvictions { get; set; }
              
        //public List<Conviction> ConvictionsList { get; set; } = new List<Conviction>();
        private City city { get; set; }

        public ConvictionAssembler(City c)
        {
            city = c;
        }

        public Conviction generateConviction(string pathToConv)
        {
            pathToConvictions = pathToConv;
            Conviction conviction = new Conviction();
            Random rnd = new Random();
            conviction.ConvictionType = (convicType)rnd.Next(0, 6);
            conviction.ConvictionCommitDate = DateTime.Now.AddHours(-rnd.Next(0, 24));
            int distNumber = rnd.Next(1, city.Districts.Count + 1);
            
            //определяем лицо совершившее преступление
            while (true)
            {
                int i = rnd.Next(0, city.Districts[distNumber].Citizens.Count + 1);               
                if (city.Districts[distNumber].Citizens[i].GetType().ToString() == "Adult")
                {
                    conviction.personCommitConviction = city.Districts[distNumber].Citizens[i];
                    conviction.personCommitConviction.Convictions.Add(conviction);
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
            catch (Exception)
            {
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
        public void Investigate()
        {

        }    
    }
}
