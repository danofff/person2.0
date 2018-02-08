using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterPeople;
using person;

namespace SmartCity
{
    public class GenerateCity
    {
        //вспомогательная статическая рандомная переменная
        private static Random rnd;
        public GenerateCity()
        {
            districtCountHandler = 0;
            rnd = new Random();
        }
        //статическая переменная для подсчета количества районов в городе
        private static int districtCountHandler;       
        public City generateCity(int districtCount)
        {
            City c = new City();
            for(int i = 0; i < districtCount; i++)
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
            HumanGenerator hg = new HumanGenerator();
                                   
            for (int i = 0; i < rnd.Next(5,11); i++)
            {
                d.Citizens.Add(hg.AdultGenerator());
                if (i % 3 == 0)
                {
                    d.Citizens.Add(hg.KidGenerator());
                }
            }
            return d;
        }


    }
}
