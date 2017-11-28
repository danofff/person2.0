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
        public ID IdGenerator()
        {
            ID randomId = new ID();
            DateTime idStart = new DateTime();
            randomId.Number=((""+rnd.Next(1000,10000))+rnd.Next(1000, 10000))+rnd.Next(1000, 10000);
            while (true)
            {
                while (!DateTime.TryParse(rnd.Next(1, 31) + "." + rnd.Next(1, 13) + "." + rnd.Next(DateTime.Now.AddYears(-10).Year, DateTime.Now.Year+1), out idStart))
                {

                }
                if (idStart<DateTime.Now)
                {
                    break;
                }
            }
            randomId.Date = idStart;
            randomId.ExpireDate = idStart.AddYears(10);
            return randomId;
        }
    }
}
