using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{
    /// <summary>
    /// LoginUser class
    /// </summary>
    [DataContract]
    public class RawDriverSummary
    {
        /// <summary>
        /// StartTime
        /// Properties for StartTime datamember
        /// </summary>
        [DataMember]
        public DateTime? StartTime
        {
            get;
            set;
        }

        /// <summary>
        /// EndTime
        /// Properties for EndTime datamember
        /// </summary>
        [DataMember]
        public DateTime? EndTime
        {
            get;
            set;
        }

        /// <summary>
        /// CurrentLoginID
        /// Properties for CurrentLoginID datamember
        /// </summary>
        [DataMember]
        public Int32? CurrentLoginID
        {
            get;
            set;
        }

        /// <summary>
        /// SessionID
        /// Properties for SessionID datamember
        /// </summary>
        [DataMember]
        public Guid SessionID
        {
            get;
            set;
        }

        /// <summary>
        /// DriverState
        /// Properties for DriverState datamember
        /// </summary>
        [DataMember]
        public String DriverState
        {
            get;
            set;
        }

      
    }
}
