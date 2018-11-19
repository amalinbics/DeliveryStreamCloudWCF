using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{


    [DataContract]
    public class VehicleMeters
    {
        [DataMember]
        public Int32 MeterID
        {
            get;
            set;
        }

        [DataMember]
        public Int32 VehicleID
        {
            get;
            set;
        }

        [DataMember]
        public String Code
        {
            get;
            set;
        } 

        [DataMember]
        public String CustomerID
        {
            get;
            set;
        } 
        
        [DataMember]
        public Boolean NeedUpdate
        {
            get;
            set;
        }
    }

    [DataContract]
    public class VehicleMetersTotalizer
    {
        [DataMember]
        public Int32 MeterID
        {
            get;
            set;
        }

        [DataMember]
        public Decimal MeterTotal
        {
            get;
            set;
        }

        [DataMember]
        public Decimal ShiftTotal
        {
            get;
            set;
        }

        [DataMember]
        public Decimal Total
        {
            get;
            set;
        }

        [DataMember]
        public Int32 ClientID
        {
            get;
            set;
        }
        
        [DataMember]
        public String Code
        {
            get;
            set;
        } 

        [DataMember]
        public Guid SessionID
        {
            get;
            set;
        }
        [DataMember]
        public Int32 Updatedby
        {
            get;
            set;
        }
        [DataMember]
        public String VehicleID
        {
            get;
            set;
        }
    }
}
