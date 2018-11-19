using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{
    /// <summary>
    /// GetVehicleDetails class
    /// </summary>
     
    [DataContract]
    public class GetVehicleDetails
    {
        /// <summary>
        /// VehicleID
        /// </summary>
        [DataMember]
        public Int32 VehicleID
        {
            get;
            set;
        }
        /// <summary>
        /// VehicleCode
        /// </summary>
        [DataMember]
        public string VehicleCode
        {
            get;
            set;
        }
        /// <summary>
        /// VehicleTypeCompartment
        /// </summary>
        [DataMember]
        public List<GetVehicleTypeCompartment> VehicleTypeCompartment
        {
            get;
            set;
        }
        
    }
    [DataContract]
    public class GetVehicleTypeCompartment
    {


        /// <summary>
        /// CompartmentCode
        /// </summary>
        [DataMember]
        public string CompartmentCode
        {
            get;
            set;
        }
        /// <summary>
        /// CompartmentID
        /// </summary>
        [DataMember]
        public Int32 CompartmentID
        {
            get;
            set;
        }


    }
}
