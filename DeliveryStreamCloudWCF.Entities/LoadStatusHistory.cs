using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{
    /// <summary>
    /// LoadStatusHistory class
    /// </summary>
    [DataContract]
    public class LoadStatusHistory
    {
        /// <summary>
        /// LoadID
        /// Properties for LoadID datamember
        /// </summary>
        [DataMember]
        public Guid LoadID
        {
            get;
            set;
        }

        /// <summary>
        /// LoadStatusID
        /// Properties for LoadStatusID datamember
        /// </summary>
        [DataMember]
        public string LoadStatusID
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
        /// City
        /// Properties for Longitude datamember
        /// </summary>
        [DataMember]
        public string City
        {
            get;
            set;
        }

        /// <summary>
        /// State
        /// Properties for Longitude datamember
        /// </summary>
        [DataMember]
        public string State
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
