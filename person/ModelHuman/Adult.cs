using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using person.Education;
using person.ModelIdentity;
using MasterCrime;

namespace person.ModelHuman
{
    public class Adult : Person
    {
        public List<Kid> Kids { get; set; }
        public bool IsMarried { get; set; } = false;
        public bool IsWorking { get; set; } = false;
        public List<School> Schools { get; set; }
        public List<College> Colleges { get; set; }
        public List<Conviction> Convictions { get; set; } = new List<Conviction>();

        //конструктор
        public Adult():this(new List<School>()){}
        public Adult(List<School> schools):this(schools,new List<College>()){}
        public Adult(List<School> schools, List<College> colleges):this(schools,colleges,new List<Kid>()){}

        //ПОСМОТРИ На эту конструкцию
        public Adult(List<School> schools, List<College> colleges,List<Kid> kids) : base()//<<<<<<---------
        {
            Schools = schools;
            Colleges = colleges;
        }

        public override void PrintFullInfo()
        {
            base.PrintFullInfo();
            Console.WriteLine("Kids Info :");
            foreach (var item in this.Kids)
            {
                Console.WriteLine("Name: {0}", item.Name);
                Console.WriteLine("Age: {0}", item.Age);
                Console.WriteLine("Date of burth: {0:d}", item.DateOfBurth);
            }
            Console.WriteLine("Married: {0}", this.IsMarried ? "yes" : "no");
            Console.WriteLine("Working: {0}", this.IsWorking ? "yes" : "no");

            foreach(var item in Schools)
                item.PrintEducationInfo();

            foreach (var item in Colleges)
                item.PrintEducationInfo();

            foreach (var item in Convictions)
                Console.WriteLine(item);

            Console.ResetColor();
        }
    }
}
