using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneratorName;
using person.ModelHuman;
using person;


namespace PoliceMaster
{
    public class PoliceGenerator
    {
        private static Random rnd = new Random();
        public PolicePeople PoliceGenerate()
        {
            PolicePeople randPolice = new PolicePeople { Gender = (Sex) rnd.Next(0, 2)};
            // gendor generator
            //name generator
            Generator g = new Generator();
            randPolice.Name = g.GenerateDefault(randPolice.Gender == Sex.female ? Gender.woman : Gender.man);
            randPolice.Name = randPolice.Name.Replace("<center><b><font size=7>", "").Replace("\n", "").Replace("</font></b></center>", "");
            randPolice.Name = randPolice.Name.Substring(1, randPolice.Name.Length - 1);
            //age and dateburth generator
            randPolice.Age = rnd.Next(16, 55);
            //randPolice.DateOfBurth=GenerateBirthDate(randPolice);
            IdGeneratorForAdults idGen = new IdGeneratorForAdults();
            randPolice.Ids.Add(idGen.IdGenerator());
            randPolice.Rang = (rang)rnd.Next(0, 5);                     
            return randPolice;
        }

        //date burth generator
        private DateTime GenerateBirthDate(Person p)
        {
            Random rnd = new Random();
            DateTime date = new DateTime();
            int year = DateTime.Now.AddYears(-p.Age).Year;
            DateValidate:
            while (!DateTime.TryParse(rnd.Next(1, 32) + "." + rnd.Next(1, DateTime.Now.Month+1) + "." + year, out date))
            {
                
            }
            if (date > DateTime.Now)
                goto DateValidate;
           
            return date;
        }
    }
}
