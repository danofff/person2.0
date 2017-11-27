using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace person.Education
{
    public class College:Education
    {
        private string prof;
        public string Prof
        {
            get { return prof; }
            set { prof = value; }
        }
        private string faculty;
        public string Faculty
        {
            get { return faculty; }
            set { faculty = value; }
        }

        public College() : base() { }
        public College(string name, string faculty,string profession):this(name,Convert.ToDateTime("01.09.1900"), Convert.ToDateTime("01.06.1905"))
        {
            this.Name = name;
            this.Faculty = faculty;
            this.Prof = profession;
        }
        public College(string name, DateTime stDate, DateTime gradDate)
        {
            this.Name = name;
            this.StartDate = stDate;
            this.GraduateDate = gradDate;
        }
        public override void printEducationInfo()
        {
            base.printEducationInfo();
            Console.WriteLine("Faculty: {0}",this.Faculty);
            Console.WriteLine("Profession: {0}",this.Prof);
        }
    }
}
