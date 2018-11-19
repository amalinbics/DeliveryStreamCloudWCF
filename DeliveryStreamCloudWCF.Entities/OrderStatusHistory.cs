using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{
    /// <summary>
    /// OrderStatusHistory class
    /// </summary>
    [DataContract]
    public class OrderStatusHistory
    {
        /// <summary>
        /// OrderID
        /// Properties for OrderID datamember
        /// </summary>
        [DataMember]
        public Guid OrderID
        {
            get;
            set;
        }

        /// <summary>
        /// OrderStatusID
        /// Properties for OrderStatusID datamember
        /// </summary>
        [DataMember]
        public string OrderStatusID
        {
            get;
            set;
        }

        /// <summary>
        /// Latitude
        /// Properties for Latitude datamember
        /// </summary>
        [DataMember]
        public string Latitude
        {
            get;
            set;
        }

        /// <summary>
        /// Longitude
        /// Properties for Longitude datamember
        /// </summary>
        [DataMember]
        public string Longitude
        {
            get;
            set;
        }

        /// <summary>
        /// NeedUpdate
        /// Properties for NeedUpdate datamember
        /// </summary>
        [DataMember]
        public Boolean NeedUpdate
        {
            get;
            set;
        }

        /// <summary>
        /// UpdatedBy
        /// Properties for UpdatedBy datamember
        /// </summary>
        [DataMember]
        public Int32 UpdatedBy
        {
            get;
            set;
        }

        /// <summary>
        /// DateTime
        /// Properties for DateTime datamember
        /// </summary>
        [DataMember]
        public DateTime DateTime
        {
            get;
            set;
        }
    }
}
