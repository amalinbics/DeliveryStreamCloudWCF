//2014.09.09, CR#64208, Madhu, Add Modified date to GetInspectionElementsData
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{
    [DataContract]
    public class InspectionElements
    {
        [DataMember]
        public Int32 SequenceID
        {
            get;
            set;
        }
        [DataMember]
        public String Description
        {
            get;
            set;
        }
        [DataMember]
        public DateTime? Modifieddate
        {
            get;
            set;
        }
    }
}
