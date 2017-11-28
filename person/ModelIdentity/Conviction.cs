using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace person.ModelIdentity
{
    public class Conviction
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
        public int convictionLength { get; set; }
        
        public Conviction():this("no reason")
        { }
        public Conviction(string reason):this(reason, 0)
        {
            this.Reason = reason;
        }
        public Conviction(string reason, int length):this(reason,length,Convert.ToDateTime("01.01.1900"))
        {
            this.Reason = reason;
            this.convictionLength = length;
        }
        public Conviction(string reason, int length,DateTime start)
        {
            this.Reason = reason;
            this.convictionLength = length;
            this.ConvictionStart = start;
        }
        public override string ToString()
        {
            return "Reason: " + this.Reason + "\nLength: " + this.convictionLength + " years" + "\nStart date: " 
                + this.ConvictionStart+"\nGet out date:"+this.ConvictionStart.AddYears(this.convictionLength);
        }
    }
}
