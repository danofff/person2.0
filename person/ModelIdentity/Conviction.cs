using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace person.ModelIdentity
{
    public class Conviction
    {
        public string Reason { get; set; }
        public DateTime ConvictionStart { get; set; }
        public int ConvictionLength { get; set; }
        
        public Conviction():this("no reason"){ }
        public Conviction(string reason):this(reason, 0){}
        public Conviction(string reason, int length):this(reason,length, DateTime.MinValue) {}
        public Conviction(string reason, int length,DateTime start)
        {
            Reason = reason;
            ConvictionLength = length;
            ConvictionStart = start;
        }

        public override string ToString()
        {
            //Знаешь, потом как тяжело тестирвать если не используешь дополнительнупеременную.
            string result = "Reason: " + Reason 
                            + "\nLength: " + ConvictionLength 
                            + " years" + "\nStart date: "
                            + ConvictionStart + "\nGet out date:" 
                            + ConvictionStart.AddYears(ConvictionLength);
            return result;
        }
    }
}
