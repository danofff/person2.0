using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using person.ModelHuman;

namespace MasterCrime
{
    public enum convicType { robbery, homoside, drugs, murder, fight, not_udentify };
    public class Conviction
    {
        public convicType Type { get; set; }
        public DateTime ConvictionCommit { get; set; }
        public Adult personCommitConviction { get; set; }
        public Conviction():this(convicType.not_udentify){ }
        public Conviction(convicType type):this(type,DateTime.Now){}
        public Conviction(convicType type, DateTime start):this(type,start, new Adult())
        {
            Type = type;
            ConvictionCommit = start;
        }
        public Conviction(convicType type, DateTime start,Adult person)
        {
            Type = type;
            ConvictionCommit = start;
            personCommitConviction = person;
            Adult a = new Adult();
        }

        public override string ToString()
        {
            string result = "Type: " + Type.ToString() +
                String.Format("Date: {d:0}", ConvictionCommit) +
                personCommitConviction.Name;
            return result;
        }
    }
}
