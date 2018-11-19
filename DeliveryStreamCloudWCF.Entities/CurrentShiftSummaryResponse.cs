using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{
    /// <summary>
    /// CurrentShiftSummary class
    /// </summary>
    [DataContract]

   public class CurrentShiftSummaryResponse
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
        /// OnDuty
        /// Properties for OnDuty datamember
        /// </summary>
        [DataMember]
        public Decimal OnDuty
        {
            get;
            set;
        }

        /// <summary>
        /// SleeperRig
        /// Properties for SleeperRig datamember
        /// </summary>
        [DataMember]
        public Decimal SleeperRig
        {
            get;
            set;
        }

        /// <summary>
        /// Driving
        /// Properties for Driving datamember
        /// </summary>
        [DataMember]
        public Decimal Driving
        {
            get;
            set;
        }

        /// <summary>
        /// OffDuty
        /// Properties for OffDuty datamember
        /// </summary>
        [DataMember]
        public Decimal OffDuty
        {
            get;
            set;
        }

    }
}
