using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using person.ModelHuman;
using System.Xml.Serialization;
using System.IO;

namespace MasterCrime
{
    public class Arhiv
    {
        private string pathToConvictions { get; } = "convictions.xml";
        public List<Conviction> arhiv { get; set; }
        public Arhiv()
        {
            arhiv = new List<Conviction>();
            arhiv = GetConvictions();
        }

        public void RefreshConvictionList()
        {
            arhiv = null;
            arhiv = GetConvictions();
        }
        public void printArhiv()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nАРХИВ ПРЕСТУПЛЕНИЙ");
            foreach (Conviction item in arhiv)
            {
                if(arhiv.Count!=0)
                    Console.WriteLine(item+"\n");
                else
                    Console.WriteLine("Нет совершенных преступлений");
            }
        }

        private List<Conviction> GetConvictions()
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
    }
}
