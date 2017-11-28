using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace person.ModelHuman
{
    public enum invalid { first, second, third, none };
    class Invalid:Adult
    {
        private double benefit;
        public double Benefit
        {
            get { return benefit; }
            set { benefit = value; }
        }
        public Invalid():this(invalid.none) { }
        public Invalid(invalid inv):this(inv,0)
        {
        }
        public Invalid(invalid inv, double benefit)
        {
            this.Benefit = benefit;
        }

        public override void printFullInfo()
        {
            base.printFullInfo();
            Console.WriteLine("Invalid group: {0}",this.inv);
            Console.WriteLine("Benefints: {0:c}",this.Benefit);
        }
    }
}
