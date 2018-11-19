using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{
    [DataContract]
    public class DeliveryXMLResponse
    {
        
        [DataMember]
        public Guid OrderID
        {
            get;
            set;
        }

        [DataMember]
        public Boolean Status
        {
            get;
            set;
        }
    }
}
