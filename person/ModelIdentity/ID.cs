using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace person.ModelIdentity
{
    public class ID
    {
        private string number;

        public string Number
        {
            get { return number; }
            set { number = value; }
        }
        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        private DateTime expireDate;

        public DateTime ExpireDate
        {
            get { return expireDate; }
            set { expireDate = value; }
        }

        public ID():this("000000000000")
        {

        }
        public ID(string number):this(number,DateTime.Now.AddYears(-10))
        {
            this.Number = number;
        }
        public ID(string number,DateTime date)
        {
            this.Number = number;
            this.Date = date;
            this.ExpireDate = this.Date.AddYears(10);
        }

        public void printIdInfo()
        {
            Console.WriteLine("Number: {0}",this.Number);
            Console.WriteLine("Date of issue: {0:d}", this.Date);
            Console.WriteLine("Expire date: {0:d}", this.ExpireDate);
        }
    }
}
