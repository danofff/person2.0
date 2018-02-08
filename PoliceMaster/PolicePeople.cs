using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using person;
using person.ModelHuman;

namespace PoliceMaster
{
    public enum rang { officer, detective, sergeant, lieutenant, Captain };
    public class PolicePeople:Adult
    {
        public PolicePeople():base()
        {
           IsWorking = true;
           freeStatus = true;
        }
        public rang Rang { get; set; }
        public double Salary { get; set; }
        public bool freeStatus { get; set; }


        public override void PrintShortInfo()
        {
            base.PrintShortInfo();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Rang: {Rang}");
            Console.WriteLine("Is free: {0}", this.freeStatus ? "yes" : "no");
            Console.ResetColor();
        }
        public override void PrintFullInfo()
        {
            base.PrintFullInfo();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Rang: {Rang}");
            Console.WriteLine("Is free: {0}", this.freeStatus ? "yes" : "no");
            Console.ResetColor();
        }
    }
}
