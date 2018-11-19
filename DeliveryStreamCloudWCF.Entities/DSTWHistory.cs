using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{


    [DataContract]
    public class DSTWHistory
    {

        [DataMember]
        public List<BOLCompartments> BODHistory
        {
            get;
            set;
        }

        [DataMember]
        public List<BOLCompartments> EODHistory
        {
            get;
            set;
        }

        [DataMember]
        public List<DeliveryDetails> DeliveryHistory
        {
            get;
            set;
        }

        [DataMember]
        public List<VehicleMetersTotalizer> BODVehicleMeterTotalizer
        {
            get;
            set;
        }

        [DataMember]
        public List<VehicleMetersTotalizer> EODVehicleMeterTotalizer
        {
            get;
            set;
        }
     
    }
}
