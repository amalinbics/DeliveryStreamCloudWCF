using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DeliveryStreamCloudWCF.Entities
{
    /// <summary>
    /// DeliveryDetails class
    /// </summary>
    [DataContract]
    public class DeliveryDetails
    {
        /// <summary>
        /// OrderItemID
        /// Properties for OrderItemID datamember
        /// </summary>
        [DataMember]
        public Guid OrderItemID
        {
            get;
            set;
        }

        /// <summary>
        /// ID
        /// Properties for ID datamember
        /// </summary>
        [DataMember]
        public Guid ID
        {
            get;
            set;
        }

        /// <summary>
        /// GrossQty
        /// Properties for GrossQty datamember
        /// </summary>
        [DataMember]
        public Decimal GrossQty
        {
            get;
            set;
        }

        /// <summary>
        /// NetQtyQty
        /// Properties for NetQtyQty datamember
        /// </summary>
        [DataMember]
        public Decimal NetQtyQty
        {
            get;
            set;
        }

        /// <summary>
        /// DeliveryDateTime
        /// Properties for DeliveryDateTime datamember
        /// </summary>
        [DataMember]
        public DateTime DeliveryDateTime
        {
            get;
            set;
        }

        /// <summary>
        /// BeforeVolume
        /// Properties for BeforeVolume datamember
        /// </summary>
        [DataMember]
        public Decimal? BeforeVolume
        {
            get;
            set;
        }

        /// <summary>
        /// AfterVolume
        /// Properties for AfterVolume datamember
        /// </summary>
        [DataMember]
        public Decimal? AfterVolume
        {
            get;
            set;
        }

        /// <summary>
        /// DeliveryQtyVarianceReason 
        /// Properties for DeliveryQtyVarianceReason  datamember
        /// </summary>
        [DataMember]
        public string DeliveryQtyVarianceReason 
        {
            get;
            set;
        }
        /// <summary>
        /// BOLNo 
        /// Properties for BOLNo  datamember
        /// </summary>
        [DataMember]
        public string BOLNo
        {
            get;
            set;
        }

         
    }

    [DataContract]
    public class DeliveryDetailsData
    {
        
        /// <summary>
        /// GrossQty
        /// Properties for GrossQty datamember
        /// </summary>
        [DataMember]
        public Decimal GrossQty
        {
            get;
            set;
        }

        /// <summary>
        /// NetQtyQty
        /// Properties for NetQtyQty datamember
        /// </summary>
        [DataMember]
        public Decimal NetQtyQty
        {
            get;
            set;
        }

       

        /// <summary>
        /// BeforeVolume
        /// Properties for BeforeVolume datamember
        /// </summary>
        [DataMember]
        public String BeforeVolume
        {
            get;
            set;
        }

        /// <summary>
        /// AfterVolume
        /// Properties for AfterVolume datamember
        /// </summary>
        [DataMember]
        public String AfterVolume
        {
            get;
            set;
        }

        /// <summary>
        /// DeliveryQtyVarianceReason 
        /// Properties for DeliveryQtyVarianceReason  datamember
        /// </summary>
        [DataMember]
        public string DeliveryQtyVarianceReason
        {
            get;
            set;
        }
        /// <summary>
        /// BOLNo 
        /// Properties for BOLNo  datamember
        /// </summary>
        [DataMember]
        public string BOLNo
        {
            get;
            set;
        }
    }
}
