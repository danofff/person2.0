using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace person.ModelHuman
{
    public enum convicType { robbery, homoside, drugs, murder, fight, not_udentify };
    [Serializable]
    public class Conviction
    {
        public convicType ConvictionType { get; set; }
        public DateTime ConvictionCommitDate { get; set; }
        public Person personCommitConviction { get; set; }
        public Conviction():this(convicType.not_udentify){ }
        public Conviction(convicType type):this(type,DateTime.Now){}
        public Conviction(convicType type, DateTime start):this(type,start, new Adult())
        {
            ConvictionType = type;
            ConvictionCommitDate = start;
        }
        public Conviction(convicType type, DateTime start,Adult person)
        {
            ConvictionType = type;
            ConvictionCommitDate = start;
            personCommitConviction = person;
            personCommitConviction.Convictions.Add(this);
        }

        public override string ToString()
        {
            string result = "Type: " + ConvictionType.ToString() +
                String.Format("Date: {d:0}", ConvictionCommitDate) +
                personCommitConviction.Name;
            return result;
        }
    }
}
