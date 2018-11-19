using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{


    [DataContract]
    public class VehicleCompartment
    {
        [DataMember]
        public Int32 CompartmentID
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
        public List<BOLCompartments> BolCompartment
        {
            get;
            set;
        }

        [DataMember]
        public Int32 Capacity
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
        [DataMember]
        public List<Cloud_TW_GetVehicleSiteID> VehicleINSiteID
        {
            get;
            set;
        }
        [DataMember]
        public String IsAnyDelivered
        {
            get;
            set;
        }

        [DataMember]
        public List<VehicleMeters> VehicleMeter
        {
            get;
            set;
        }
        [DataMember]
        public List<VehicleMetersTotalizer> VehicleMeterTotalizer
        {
            get;
            set;
        }
     
    }
}
