using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace person.Education
{
    public abstract class Education
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime GraduateDate { get; set; }
        public string Adress { get; set; }
        public List<string> PhoneNumbers { get; set; }

        protected Education():this("Noname") { }
        protected Education (string name):this(name, DateTime.MinValue) {}
        protected Education(string name, DateTime startDate):this(name, startDate, DateTime.MinValue) {}
        protected Education(string name, DateTime startDate, DateTime graduateDate)
        {
            PhoneNumbers = new List<string>();
            Name = name;
            StartDate = startDate;
            GraduateDate = graduateDate;
        }

        /// <summary>
        /// Моетод, для вывода информации об образованиия
        /// </summary>
        public virtual void PrintEducationInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Adress: {Adress}");
            Console.WriteLine("Enterance date: {0:d}", StartDate);
            Console.WriteLine("Graduate date: {0:d}", GraduateDate);
            Console.WriteLine("Phone numbers: ");

            if (PhoneNumbers.Count != 0)
                foreach (string t in PhoneNumbers)
                    Console.WriteLine(t);
            else
                Console.WriteLine("No data");
        }
    }
}
