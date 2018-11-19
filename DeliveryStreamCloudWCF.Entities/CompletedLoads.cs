using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{
    /// <summary>
    /// CompletedLoads class
    /// </summary>
    [DataContract]
    public class CompletedLoads
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
        /// LoadStatusID
        /// Properties for LoadStatusID datamember
        /// </summary>
        [DataMember]
        public String LoadStatusID
        {
            get;
            set;
        }

        /// <summary>
        /// LastUpdatedTime
        /// Properties for LastUpdatedTime datamember
        /// </summary>
        [DataMember]
        public DateTime LastUpdatedTime
        {
            get;
            set;
        }
    }
}
