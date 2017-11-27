using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace person.Education
{
    public abstract class Education
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private DateTime startDate;
        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        private DateTime graduateDate;
        public DateTime GraduateDate
        {
            get { return graduateDate; }
            set { graduateDate = value; }
        }

        private string adress;
        public string Adress
        {
            get { return adress; }
            set { adress = value; }
        }
        private List<string> phoneNumbers;
        public List<string> PhoneNumbers
        {
            get { return phoneNumbers; }
            set { phoneNumbers=value; }
        }
        public Education():this("Noname") { }
        public Education (string name):this(name, Convert.ToDateTime("01.09.1900"))
        {
            PhoneNumbers = new List<string>();
            Name = name;
        }
        public Education(string name, DateTime startDate):this(name, startDate,Convert.ToDateTime("01.06.1910"))
        {
            PhoneNumbers = new List<string>();
            this.Name = name;
            this.StartDate = startDate;
        }
        public Education(string name, DateTime startDate, DateTime graduateDate)
        {
            PhoneNumbers = new List<string>();
            this.Name = name;
            this.StartDate = startDate;
            this.GraduateDate = graduateDate;
        }
        public virtual void printEducationInfo()
        {
            Console.WriteLine($"Name: {this.Name}");
            Console.WriteLine($"Adress: {this.Adress}");
            Console.WriteLine("Enterance date: {0:d}", this.StartDate);
            Console.WriteLine("Graduate date: {0:d}", this.GraduateDate);
            Console.WriteLine("Phone numbers: ");
            if (this.PhoneNumbers.Count != 0)
            {
                for (int i = 0; i < this.PhoneNumbers.Count; i++)
                {
                    Console.WriteLine(this.PhoneNumbers[i]);
                }
            }
            else
            {
                Console.WriteLine("No data");
            }
        }
    }
}
