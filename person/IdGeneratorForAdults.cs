using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using person.ModelIdentity;

namespace person
{
    class IdGeneratorForAdults
    {
        private static Random rnd = new Random();
        public ID IDGenerator()
        {
            ID randomId = new ID();
            DateTime idStart = new DateTime();
            randomId.Number=((""+rnd.Next(1000,10000))+rnd.Next(1000, 10000))+rnd.Next(1000, 10000);
            while(!DateTime.TryParse(rnd.Next(1,31)+"."+rnd.Next(1,12)+"."+rnd.Next(DateTime.Now.AddYears(-10).Year, DateTime.Now.Year),out idStart))
            {

            }
            randomId.Date = idStart;
            randomId.ExpireDate = idStart.AddYears(10);
            return randomId;
        }
    }
}
