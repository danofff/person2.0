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

        public Kid KidGenerator()
        {
            Kid randKid = new Kid { Gender = (Sex)rnd.Next(0, 2) };
            Generator g = new Generator();
            randKid.Name = g.GenerateDefault(randKid.Gender == Sex.female ? Gender.woman : Gender.man);
            randKid.Name = randKid.Name.Replace("<center><b><font size=7>", "").Replace("\n", "").Replace("</font></b></center>", "");
            randKid.Name = randKid.Name.Substring(1, randKid.Name.Length - 1);
            //age and dateburth generator
            randKid.Age = rnd.Next(0, 16);
            randKid.DateOfBurth = GenerateBirthDate(randKid);
            IdGeneratorForAdults idGen = new IdGeneratorForAdults();
            randKid.Ids.Add(idGen.IdGenerator());
            return randKid;
        }

        //date burth generator
        public DateTime GenerateBirthDate(Person p)
        {
            Random rnd = new Random();
            DateTime date = new DateTime();
            if (rnd.Next(0, 2) == 0)
            {               
                int year = DateTime.Now.AddYears(-p.Age).Year;
                int month = rnd.Next(1, DateTime.Now.Month + 1);
                int day = rnd.Next(1, DateTime.Now.Day + 1);
                date = Convert.ToDateTime(String.Format($"{year}.{month}.{day}"));
            }
            else
            {
                int year = DateTime.Now.AddYears(-p.Age-1).Year;
                int day = rnd.Next(1,28);
                int month = 0;
                if (day > DateTime.Now.Day)
                {
                    month = rnd.Next(DateTime.Now.Month, 13);
                }
                else
                {
                    month = rnd.Next(DateTime.Now.Month + 1, 13);
                }
                date = Convert.ToDateTime(String.Format($"{year}.{month}.{day}"));
            }
            return date;
        }
    }
}
