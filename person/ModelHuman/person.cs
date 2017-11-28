using person.ModelIdentity;
using person.Education;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace person.ModelHuman
{
    public enum sex { male,female};
    public abstract class Person
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int age;
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        private DateTime dateOfBurth;
        public DateTime DateOfBurth
        {
            get { return dateOfBurth; }
            set { dateOfBurth = value; }
        }
        private sex gender;
        public sex Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        private List<ID> ids;
        public List<ID> Ids
        {
            get { return ids; }
            set { ids = value; }
        }
        private List<Adult> parents;
        public List<Adult> Parents
        {
            get { return parents; }
            set { parents = value; }
        }

        protected invalid inv { get; set; } = invalid.none;
        public Person()
        {
            Ids = new List<ID>();
            Parents = new List<Adult>();
        }
        public void printShortInfo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("MAIN INFO: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Name: {0}", this.Name);
            Console.WriteLine("Age: {0}", this.Age);
            Console.WriteLine("Date of birth: {0:d}", this.dateOfBurth);
            Console.WriteLine("Gender: {0}", this.Gender);
            Console.WriteLine("Id's Info:");
            foreach (var item in this.Ids)
            {
                item.printIdInfo();
            }
        }
        public virtual void printFullInfo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("MAIN INFO: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Name: {0}",this.Name);
            Console.WriteLine("Age: {0}", this.Age);
            Console.WriteLine("Date of birth: {0:d}", this.dateOfBurth);
            Console.WriteLine("Gender: {0}", this.Gender);
            Console.WriteLine("Id's Info:");
            foreach (var item in this.Ids)
            {
                item.printIdInfo();
            }
            Console.WriteLine("Parents Info: ");
            if (this.Parents.Count == 0)
            {
                Console.WriteLine("No data");
            }
            else
            {
                foreach (var item in this.Parents)
                {
                    Console.WriteLine("Name: {0}", item.Name);
                    Console.WriteLine("Age: {0}", item.Age);
                    Console.WriteLine("Date of burth: {0:d}", item.DateOfBurth);
                }
            }
        }
    }
}
