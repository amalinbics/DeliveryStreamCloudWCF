using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{
    [DataContract]
    public class OEStatus
    {
        [DataMember]
        public int StatusID { get; set; }

        [DataMember]
        public char StatusCode { get; set; }

        [DataMember]
        public string StatusDescr { get; set; }

        [DataMember]
        public int? Sequence { get; set; } 

        [DataMember]
        public int ClientID { get; set; }

    }
}
