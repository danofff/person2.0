using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace person.Education
{
    public enum level { elementary, middle, high}

    public class School:Education
    {
        public level Lev { get; set; }
        //constructors
        public School() : base() { }
        public School(string name, level lev)
            :this(name, lev, DateTime.MinValue, DateTime.MinValue){}
        public School(string name,level lev, DateTime stDate,DateTime gradDate)
        {
            Lev = lev;
            Name = name;
            StartDate = stDate;
            GraduateDate = gradDate;
        }
       
        public override void PrintEducationInfo()
        {
            base.PrintEducationInfo();
            Console.WriteLine($"Level: {this.Lev}");
        }

    }
}
