using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using person.Education;
using person.ModelIdentity;

namespace person.ModelHuman
{
    public class Adult:Person
    {
        private List<Kid> kids;

        public List<Kid> Kids
        {
            get { return kids; }
            set { kids = value; }
        }
        private bool isMarried=false;
        public bool IsMarried
        {
            get { return isMarried; }
            set { isMarried = value; }
        }
        private bool isWorking=false;

        public bool IsWorking
        {
            get { return isWorking; }
            set { isWorking = value; }
        }
        private List<School> schools;

        public List<School> Schools
        {
            get { return schools; }
            set { schools = value; }
        }
        private List<College> colleges;
        public List<College> Colleges
        {
            get { return colleges; }
            set { colleges = value; }
        }
        private List<Conviction> convictions=new List<Conviction>();

        public List<Conviction> Convictions
        {
            get { return convictions; }
            set { convictions = value; }
        }

        //конструктор
        public Adult():base()
        {
            Kids = new List<Kid>();
            Schools = new List<School>();
            Colleges = new List<College>();

        }
        public Adult(List<School> schools):this(schools,new List<College>())
        {
            this.Schools = schools;
        }
        public Adult(List<School> schools, List<College> colleges):this(schools,colleges,new List<Kid>())
        {
            this.Colleges = colleges;
        }
        public Adult(List<School> schools, List<College> colleges,List<Kid> kids)
        {
            this.Kids = kids;
        }
        public override void printFullInfo()
        {
            base.printFullInfo();
            Console.WriteLine("Kids Info :");
            foreach (var item in this.Kids)
            {
                Console.WriteLine("Name: {0}", item.Name);
                Console.WriteLine("Age: {0}", item.Age);
                Console.WriteLine("Date of burth: {0:d}", item.DateOfBurth);
            }
            Console.WriteLine("Married: {0}", this.IsMarried ? "yes" : "no");
            Console.WriteLine("Working: {0}", this.IsWorking ? "yes" : "no");
            foreach(var item in schools)
            {
                item.printEducationInfo();
            }
            foreach (var item in Colleges)
            {
                item.printEducationInfo();
            }
            foreach (var item in Convictions)
            {
                Console.WriteLine(item);
            }
            Console.ResetColor();
        }
    }
}
