using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace person.ModelIdentity
{
    class Conviction
    {
        private string reason;

        public string Reason
        {
            get { return reason; }
            set { reason = value; }
        }

        private DateTime convictionStart;

        public DateTime ConvictionStart
        {
            get { return convictionStart; }
            set { convictionStart = value; }
        }
        public double convictionLength { get; set; }
        
        public Conviction():this("no reason")
        { }
        public Conviction(string reason):this(reason, 0.0)
        {
            this.Reason = reason;
        }
        public Conviction(string reason,double length):this(reason,length,Convert.ToDateTime("01.01.1900"))
        {
            this.Reason = reason;
            this.convictionLength = length;
        }
        public Conviction(string reason,double length,DateTime start)
        {
            this.Reason = reason;
            this.convictionLength = length;
            this.ConvictionStart = start;
        }
    }
}
