using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace person.ModelIdentity
{
    /*
     * ПОЖАЛУЙСТА
     * Не используй такие имена для класса!!!
     */
    public class ID
    {
        public string Number { get; set; }
        public DateTime Date { get; set; }

        public DateTime ExpireDate { get; set; }

        public ID():this("000000000000"){}
        public ID(string number):this(number,DateTime.Now.AddYears(-10)){}
        public ID(string number,DateTime date)
        {
            Number = number;
            Date = date;
            ExpireDate = this.Date.AddYears(10);
        }

        /// <summary>
        /// Методвывода информации
        /// </summary>
        public void PrintIdInfo()
        {
            Console.WriteLine("Number: {0}",this.Number);
            Console.WriteLine("Date of issue: {0:d}", this.Date);
            Console.WriteLine("Expire date: {0:d}", this.ExpireDate);
        }
    }
}
