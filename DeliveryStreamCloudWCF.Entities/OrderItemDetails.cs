using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{


    [DataContract]
    public class OrderItemDetails
    {
        [DataMember]
        public Guid OrderID
        {
            get;
            set;
        }

        [DataMember]
        public Guid OrderItemID
        {
            get;
            set;
        }

        [DataMember]
        public String ProdCode
        {
            get;
            set;
        }


        [DataMember]
        public Decimal OrderedQty
        {
            get;
            set;
        }

        [DataMember]
        public String OrderNo 
        {
            get;
            set;
        }

        [DataMember]
        public String ProdName 
        {
            get;
            set;
        }

        [DataMember]
        public String Blend 
        {
            get;
            set;
        }

        [DataMember]
        public int? ARShipToTankID
        {
            get;
            set;
        }
        [DataMember]
        public String ARShipToTankCode
        {
            get;
            set;
        }
    }
}
