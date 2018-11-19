using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace DeliveryStreamCloudWCF.Entities
{
    [DataContract]
   public class Inspection
    {
        [DataMember]
        public Guid SessionID
        {
            get;
            set;
        }

        [DataMember]
        public Boolean PreDuty_Inspection
        {
            get;
            set;
        }

        [DataMember]
        public DateTime? PreDuty_InspectionDateTime
        {
            get;
            set;
        }

        [DataMember]
        public Boolean PreDutyViolation
        {
            get;
            set;
        }

        [DataMember]
        public Boolean PostDuty_Inspection
        {
            get;
            set;
        }

        [DataMember]
        public DateTime? PostDuty_InspectionDateTime
        {
            get;
            set;
        }

        [DataMember]
        public Boolean PostDutyViolation
        {
            get;
            set;
        }
    }
}
