using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{
    /// <summary>
    /// Vehicle class
    /// </summary>
    [DataContract]
    public class Vehicle
    {
        /// <summary>
        /// ID
        /// Properties for ID datamember
        /// </summary>
        [DataMember]
        public Int32 ID
        {
            get;
            set;
        }

        /// <summary>
        /// CustomerID
        /// Properties for CustomerID datamember
        /// </summary>
        [DataMember]
        public String CustomerID
        {
            get;
            set;
        }

        /// <summary>
        /// VehicleCode
        /// Properties for VehicleCode datamember
        /// </summary>
        [DataMember]
        public String VehicleCode
        {
            get;
            set;
        }
    }
}
