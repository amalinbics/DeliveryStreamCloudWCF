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
   public class Break
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
       /// BreakStartTime
       /// Properties for BreakStartTime datamember
       /// </summary>
       [DataMember]
       public DateTime BreakStartTime
       {
           get;
           set;
       }
       /// <summary>
       /// BreakEndTime
       /// Properties for BreakEndTime datamember
       /// </summary>
       [DataMember]
       public DateTime BreakEndTime
       {
           get;
           set;
       }
       /// <summary>
       /// TimeViolation
       /// Properties for TimeViolation datamember
       /// </summary>
       [DataMember]
       public String TimeViolation
       {
           get;
           set;
       }
       /// <summary>
       /// MovingViolation
       /// Properties for MovingViolation datamember
       /// </summary>
       [DataMember]
       public String MovingViolation
       {
           get;
           set;
       }

       /// <summary>
       /// TimeViolation
       /// Properties for TimeViolation datamember
       /// </summary>
       [DataMember]
       public String NoBreakViolation
       {
           get;
           set;
       }


    }
}
