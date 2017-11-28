using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace person.Education
{
    public class College:Education
    {
        public string Prof { get; set; }
        public string Faculty { get; set; }

        public College() : base() { }
        public College(string name, string faculty,string profession)
            :this(name, faculty, profession, DateTime.MinValue, DateTime.MinValue){}

        public College(string name, string faculty, string profession, DateTime stDate, DateTime gradDate)
        {
            Faculty = faculty;
            Prof = profession;
            Name = name;
            StartDate = stDate;
            GraduateDate = gradDate;
        }

        public override void PrintEducationInfo()
        {
            base.PrintEducationInfo();
            Console.WriteLine("Faculty: {0}",this.Faculty);
            Console.WriteLine("Profession: {0}",this.Prof);
        }
    }
}
