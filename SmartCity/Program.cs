﻿using System;
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
            //am.pathToCityServices = "smartCityService.xml";
            am.pathToCity = "city.xml";
            am.GetCity();
            

           
            /*PoliceStation ps1 = new PoliceStation();
            ps1.NamePoliceStation = "Полиция";
            ps1.CodePoliceStation=102;

            am.pathToCities = "smartCityCities.xml";*/


           
            
            // create city
            City city = new City();
            city.CityName = "Алматы";
            city.Services = new List<CityService> { cs };

            ForegroundColor = ConsoleColor.Green;
            //заселение людей в город
            WriteLine("Подождите, идет заселение людей в город");
            HumanGenerator humanGen = new HumanGenerator();
            for (int i = 0; i < 15; i++)
            {
                city.citizens.Add(humanGen.AdultGenerator());
            }
            for (int i = 0; i < 5; i++)
            {
                city.citizens.Add(humanGen.KidGenerator());
            }
            Clear();
            am.CreateCity(city);

                                             

            MasterPolice pm = new MasterPolice();
            pm.pathToStation = "policeStations.xml";
            PoliceStation ps = new PoliceStation();
            ps.city = am.GetCities()[0];
            ps.CodePoliceStation=001;
            ps.NamePoliceStation = "Тимирязева";
            pm.CreateStation(ps);
        }
    }
}
