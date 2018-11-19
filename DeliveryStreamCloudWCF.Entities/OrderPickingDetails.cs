using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{
    /// <summary>
    /// OrderPickingDetails class
    /// </summary>
     [DataContract]
    public class OrderPickingDetails
    {
         /// <summary>
         /// ID
         /// Properties for ID datamember
         /// </summary>
         [DataMember]
         public Int64 ID
         {
             get;
             set;
         }
         /// <summary>
         /// OrderNo
         /// Properties for OrderNo datamember
         /// </summary>
         [DataMember]
         public string OrderNo
         {
             get;
             set;
         }
         /// <summary>
         /// LoadNo
         /// Properties for LoadNo datamember
         /// </summary>
         [DataMember]
         public string LoadNo
         {
             get;
             set;
         }

         /// <summary>
         /// OrderItemID
         /// Properties for OrderItemID datamember
         /// </summary>
         [DataMember]
         public String OrderItemID
         {
             get;
             set;
         }

         /// <summary>
         /// PickedBy
         /// Properties for PickedBy datamember
         /// </summary>
         [DataMember]
         public Int32 PickedBy
         {
             get;
             set;
         }
         /// <summary>
         /// CustomerID
         /// Properties for CustomerID datamember
         /// </summary>
         [DataMember]
         public string CustomerID
         {
             get;
             set;
         }
         /// <summary>
         /// Status
         /// Properties for Status datamember
         /// </summary>
         [DataMember]
         public string Status
         {
             get;
             set;
         }
    }
}
