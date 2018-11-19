using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DeliveryStreamCloudWCF.Entities
{
    [DataContract]
    public class DispatchChangeLoad
    {
        [DataMember]
        public Guid LoadID
        {
            get;
            set;
        }

        /// <summary>
        /// LoadNo
        /// Properties for LoadNo datamember
        /// </summary>
        [DataMember]
        public String LoadNo
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
        /// DriverID
        /// Properties for DriverID datamember
        /// </summary>
        [DataMember]
        public Int32? DriverID
        {
            get;
            set;
        }
    }
}
