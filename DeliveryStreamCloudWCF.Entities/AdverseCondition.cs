using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{
   public class AdverseCondition
    {
       [DataMember]
       public Guid SessionID
       {
           get;
           set;
       }

       [DataMember]
       public Boolean Adverse_Condition
       {
           get;
           set;
       }

       [DataMember]
       public String AdverseConditionReason
       {
           get;
           set;
       }

       [DataMember]
       public DateTime AdverseConditionDateTime
       {
           get;
           set;
       }

    }
}
