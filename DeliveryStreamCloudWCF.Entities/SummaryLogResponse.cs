using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{
    /// <summary>
    /// SummaryLog class
    /// </summary>
    [DataContract]

  public class SummaryLogResponse
    {
        public SummaryLogResponse()
        {
            currentShift = new CurrentShiftSummaryResponse();
            cumulativeShift = new CumulativeShiftSummaryResponse();
        }

        /// <summary>
        /// CurrentShiftSummaryResponse
        /// Properties for CurrentShiftSummaryResponse datamember
        /// </summary>
        [DataMember]
        public CurrentShiftSummaryResponse currentShift
        {
            get;
            set;
        }

        /// <summary>
        /// CumulativeShiftSummaryResponse
        /// Properties for CumulativeShiftSummaryResponse datamember
        /// </summary>
        [DataMember]
        public CumulativeShiftSummaryResponse cumulativeShift
        {
            get;
            set;
        }
    }
}
