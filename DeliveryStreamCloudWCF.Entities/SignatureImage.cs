using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{
    [DataContract]
    public class SignatureImage
    {
        [DataMember]
        public String Status
        {
            get;
            set;
        }

        [DataMember]
        public DateTime? DateTime
        {
            get;
            set;
        }

        [DataMember]
        public byte[] Image
        {
            get;
            set;
        }
    }
}
