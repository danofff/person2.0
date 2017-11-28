using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using person.Education;

namespace person.ModelHuman
{
    public class Kid : Person
    {
        public List<School> Schs { get; set; }

        public Kid()
        {
            Schs = new List<School>();
        }

        public override void PrintFullInfo()
        {
            base.PrintFullInfo();

            Console.WriteLine("Schools info: ");

            if (Schs.Count != 0)
                for (int i = 0; i < this.Schs.Count; i++)
                    Schs[i].PrintEducationInfo();
            else
                Console.WriteLine("No data");
        }
    }
}
