using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using person.ModelIdentity;

namespace person
{
    public class IdGeneratorForAdults
    {
        private Random rnd = new Random();
        public ID IdGenerator()
        {
            ID randomId = new ID();          
            randomId.Number=((""+rnd.Next(1000,10000))+rnd.Next(1000, 10000))+rnd.Next(1000, 10000);           
            return randomId;
        }
    }
}
