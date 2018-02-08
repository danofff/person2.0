using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace person.ModelHuman
{
    public enum invalid { first, second, third, none };

    public class Invalid : Adult
    {
        public double Benefit { get; set; }
        public invalid invalid { get; set; }

        public Invalid():this(invalid.none) { }
        public Invalid(invalid inv):this(inv,0){}
        public Invalid(invalid inv, double benefit)
        {
            invalid = inv;
            Benefit = benefit;
        }

        public override void PrintFullInfo()
        {
            base.PrintFullInfo();
            Console.WriteLine("Invalid group: {0}",inv);
            Console.WriteLine("Benefints: {0:c}",Benefit);
        }
    }
}
