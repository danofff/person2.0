using person.ModelIdentity;
using person.Education;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace person.ModelHuman
{
    public enum Sex { male, female };

    public abstract class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBurth { get; set; }
        public Sex Gender { get; set; }
        public List<ID> Ids { get; set; }
        public List<Adult> Parents { get; set; }

        protected invalid inv { get; set; } = invalid.none;

        protected Person()
        {
            Ids = new List<ID>();
            Parents = new List<Adult>();
            IdGeneratorForAdults idGen = new IdGeneratorForAdults();
            Ids.Add(idGen.IdGenerator());
        }

        public virtual void PrintShortInfo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("MAIN INFO: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Name: {0}", this.Name);
            Console.WriteLine("Age: {0}", this.Age);
            Console.WriteLine("Date of birth: {0:d}", DateOfBurth);
            Console.WriteLine("Gender: {0}", this.Gender);
            Console.WriteLine("Id's Info:");

            foreach (var item in Ids)
                item.PrintIdInfo();
        }

        public virtual void PrintFullInfo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("MAIN INFO: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Name: {0}", Name);
            Console.WriteLine("Age: {0}", Age);
            Console.WriteLine("Date of birth: {0:d}", DateOfBurth);
            Console.WriteLine("Gender: {0}", Gender);
            Console.WriteLine("Id's Info:");

            foreach (var item in this.Ids)
                item.PrintIdInfo();

            Console.WriteLine("Parents Info: ");
            if (Parents.Count == 0) return;
            //посмотри как этоможно обыграть .. если нет данных 
            //но будь осторожен в этотммент произойдет выход из этого метода, 
            //все что ниже будет проигнорировано
            foreach (var item in Parents)
            {
                Console.WriteLine("Name: {0}", item.Name);
                Console.WriteLine("Age: {0}", item.Age);
                Console.WriteLine("Date of burth: {0:d}", item.DateOfBurth);
            }
        }
    }
}
