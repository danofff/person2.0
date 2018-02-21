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
using MasterCrime;
using System.Xml.Serialization;
using System.IO;
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

            //создаем класс управляющий преступлениями
            ConvictionAssembler convAssembl = new ConvictionAssembler(city);

            //генерируем преступление
            Conviction conv = convAssembl.generateConviction();

            //расследуем преступление
            convAssembl.Investigate(conv);

            //создаем архив
            Arhiv arhiv = new Arhiv();
            //печатаем архив преступлений
            arhiv.printArhiv();

            ForegroundColor = ConsoleColor.Red;
        }
    }
}
