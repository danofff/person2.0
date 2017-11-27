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
        public Kid()
        {
            schs = new List<School>();
        }
        private List<School> schs;
        public List<School> Schs
        {
            get { return schs; }
            set { schs = value; }
        }
        public override void printFullInfo()
        {
            base.printFullInfo();
            Console.WriteLine("Schools info: ");
            if (schs.Count != 0)
            {
                for (int i = 0; i < this.Schs.Count; i++)
                {
                    Schs[i].printEducationInfo();
                }
            }
            else
            {
                Console.WriteLine("No data");
            }
        }
    }
}
