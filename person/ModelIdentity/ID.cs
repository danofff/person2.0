using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace person.ModelIdentity
{
    
    public class ID
    {
        public string Number { get; set; }
        public ID():this("000000000000"){}
        public ID(string number) {
            this.Number = number;
        }

             /// <summary>
        /// Методвывода информации
        /// </summary>
        public void PrintIdInfo()
        {
            Console.WriteLine("Number: {0}",this.Number);
        }
    }
}
