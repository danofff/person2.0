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
        private level lev;

        public level Lev
        {
            get { return lev; }
            set { lev = value; }
        }
        //constructors
        public School() : base() { }
        public School(string name, level lev):this(name,Convert.ToDateTime("01.09.1900"), Convert.ToDateTime("01.06.1910"))
        {
            this.Name = name;
            this.Lev = lev;
        }
        public School(string name,DateTime stDate,DateTime gradDate)
        {
            this.Name = name;
            this.StartDate = stDate;
            this.GraduateDate = gradDate;
        }
       
        public override void printEducationInfo()
        {
            base.printEducationInfo();
            Console.WriteLine($"Level: {this.Lev}");
        }

    }
}
