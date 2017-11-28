using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneratorName;
using person.ModelHuman;

namespace person
{
    public class HumanGenerator
    {
        private static Random rnd = new Random();
        public Adult AdultGenerator()
        {
            Adult randAdult = new Adult {Gender = (Sex) rnd.Next(0, 2)};
            // gendor generator
            //name generator
            Generator g = new Generator();
            randAdult.Name = g.GenerateDefault(randAdult.Gender == Sex.female ? Gender.woman : Gender.man);
            randAdult.Name = randAdult.Name.Replace("<center><b><font size=7>", "").Replace("\n", "").Replace("</font></b></center>", "");
            randAdult.Name = randAdult.Name.Substring(1, randAdult.Name.Length - 1);
            //age and dateburth generator
            randAdult.Age = rnd.Next(16, 100);
            randAdult.DateOfBurth=GenerateBirthDate(randAdult);
            IdGeneratorForAdults idGen = new IdGeneratorForAdults();
            randAdult.Ids.Add(idGen.IdGenerator());
                     
            return randAdult;
        }

        //date burth generator
        public DateTime GenerateBirthDate(Adult adult)
        {
            Random rnd = new Random();
            DateTime date = new DateTime();
            int year = DateTime.Now.AddYears(-adult.Age).Year;
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
