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
        public string personCommitConviction { get; set; }
        public int DistrictOfConviction { get; set; }
        public Conviction():this(convicType.not_udentify){ }
        public Conviction(convicType type):this(type,DateTime.Now){}
        public Conviction(convicType type, DateTime start):this(type,start, "Nobody")
        {
            ConvictionType = type;
            ConvictionCommitDate = start;
        }
        public Conviction(convicType type, DateTime start,string person)
        {
            ConvictionType = type;
            ConvictionCommitDate = start;
            personCommitConviction = person;           
        }

        public override string ToString()
        {
        
            string result = "Type: " + ConvictionType.ToString() +"\nPerson commit: "+              
                personCommitConviction+"\nDate of conviction commit: "+ ConvictionCommitDate.ToString("dd.MM.yyyy H:mm:ss");

            return result;
        }
    }
}
