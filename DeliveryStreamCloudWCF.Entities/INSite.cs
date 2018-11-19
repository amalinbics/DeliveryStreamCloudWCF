using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{
    /// <summary>
    /// Break Class
    /// </summary>
   [DataContract]
    public class INSite
    {
     
        /// <summary>
        /// SessionID
        /// Properties for SessionID datamember
        /// </summary>
       [DataMember]
       public Int32 SiteID
        {
            get;
            set;
        }

       /// <summary>
       /// BreakStartTime
       /// Properties for BreakStartTime datamember
       /// </summary>
       [DataMember]
       public String Code
       {
           get;
           set;
       }
       /// <summary>
       /// BreakEndTime
       /// Properties for BreakEndTime datamember
       /// </summary>
       [DataMember]
       public String LongDescr
       {
           get;
           set;
       }
       /// <summary>
       /// TimeViolation
       /// Properties for TimeViolation datamember
       /// </summary>
       [DataMember]
       public DateTime ? LastModifiedDtTm
       {
           get;
           set;
       }
       /// <summary>
       /// MovingViolation
       /// Properties for MovingViolation datamember
       /// </summary>
       [DataMember]
       public Int32 CustomerID
       {
           get;
           set;
       }

  

    }
}
