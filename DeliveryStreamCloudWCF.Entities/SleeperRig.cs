using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{
    /// <summary>
    /// SleeperRig class
    /// </summary>
    [DataContract]
    public class SleeperRig
    {
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
        /// SleeperRigID
        /// Properties for SleeperRigID datamember
        /// </summary>
        [DataMember]
        public Guid SleeperRigID
        {
            get;
            set;
        }

        /// <summary>
        /// StartTime
        /// Properties for StartTime datamember
        /// </summary>
        [DataMember]
        public DateTime StartTime
        {
            get;
            set;
        }

        /// <summary>
        /// StartTime
        /// Properties for EndTime datamember
        /// </summary>
        [DataMember]
        public DateTime EndTime
        {
            get;
            set;
        }
    }
}
